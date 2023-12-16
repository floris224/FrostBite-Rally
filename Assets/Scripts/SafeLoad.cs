using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLoad : MonoBehaviour
{
    public CheckPoints checkPointsScript;
    public Timer timer;
    private Dictionary<int, float> checkPointTimes= new Dictionary<int, float>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    
        LoadCheckPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool SaveCheckPointTime(int checkPointIndex, float checkPointTime)
    {
        if (timer != null)
        {
            Debug.Log($"Saving checkpoint time for index {checkPointIndex}: {checkPointTime}");
            if (!checkPointTimes.ContainsKey(checkPointIndex) || timer.currentTime < checkPointTimes[checkPointIndex])
            {
                checkPointTimes[checkPointIndex] = checkPointTime;
                SafeCheckpointTimes();
                return true;
            }
            else
            {
   
               
                return false;
            }
            
        }
        else
        {
            return false;
        }
       
    }
    public void LoadCheckPoints()
    {
        if (PlayerPrefs.HasKey("CheckpointTime"))
        {
            string json = PlayerPrefs.GetString("CheckpointTime");
            Debug.Log("JasonLoaded" + json);
            checkPointTimes = JsonUtility.FromJson<Dictionary<int, float>>(json);
            Debug.Log("loaded checkpoints times " + json);
            if(checkPointTimes != null)
            {
                Debug.Log("Succesfull" + json);

            }
            else
            {
                Debug.Log("FML" + json) ;
            }
        }
        else
        {
            Debug.Log("No Saved Time");
        }
    }
    public void SafeCheckpointTimes()
    {
        string json =JsonUtility.ToJson(checkPointTimes);
        Debug.Log("CheckpointTime Json" + json);
        PlayerPrefs.SetString("CheckpointTime",json);
        
        PlayerPrefs.Save();
        Debug.Log("SavedTimes" + json);
        
    }
    public float GetCheckPointTime(int checkPointIndex)
    {
        return checkPointTimes.ContainsKey(checkPointIndex) ? checkPointTimes[checkPointIndex] : 0f;
    }
    public void ResetTimer()
    {
        timer.currentTime = 0;
        checkPointTimes.Clear();

    }

    public void OnApplicationQuit()
    {
        SaveCheckPointsExit(checkPointsScript);
    }
    public void SaveCheckPointsExit(CheckPoints checkPointss)
    {
        if(checkPointss != null)
        {
            int checkPointIndex = checkPointss.checkPointIndex;
            float checkPointsTime= checkPointss.timer.currentTime;
            SaveCheckPointTime(checkPointIndex, checkPointsTime);
        }
    }
   
}
