using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLoad : MonoBehaviour
{
    public Timer timer;
    private Dictionary<string, float> checkPointTimes= new Dictionary<string, float>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool SaveCheckPointTime(string checkPoint, float checkPointTime)
    {
        if (timer != null)
        {
            if (!checkPointTimes.ContainsKey(checkPoint) || timer.currentTime < checkPointTimes[checkPoint])
            {
                checkPointTimes[checkPoint] = timer.currentTime;
                SafeCheckpointTimes();
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
       
    }
    public void LoadCheckPoints()
    {
        if (PlayerPrefs.HasKey("CheckppointTimes"))
        {
            string json = PlayerPrefs.GetString("CheckpointTimes");
            checkPointTimes = JsonUtility.FromJson<Dictionary<string, float>>(json);
        }
    }
    public void SafeCheckpointTimes()
    {
        string json =JsonUtility.ToJson(checkPointTimes);
        PlayerPrefs.SetString("CheckpointTimes",json);
        PlayerPrefs.Save();
    }
    public void ResetTimer()
    {
        timer.currentTime = 0;
        checkPointTimes.Clear();

    }

}
