using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Saveoad : MonoBehaviour
{
    public CheckPoints[] checkPoints;
    public int checkPointIdex;
    
    public float[] loadTime;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("Time", checkPoints[checkPointIdex].checkPointTime);
        Debug.Log($"Saved Time: {checkPoints[checkPointIdex].checkPointTime}");
    }
    public void LoadData()
    {
        loadTime = new float[checkPoints.Length];
       
        for(int i = 0; i < checkPoints.Length; i++)
        {
            loadTime[i] = PlayerPrefs.GetFloat("Time" + i);
            if (loadTime[i] != 0)
            {
                checkPoints[i].checkPointRecord = loadTime[i];
                Debug.Log($"Loaded Time: {checkPoints[checkPointIdex].checkPointTime} from {loadTime}");
            }
            else
            {
                Debug.Log("TisBedTijd");
            }
        }
       
        
        
       

    }
    public float GetData()
    {
        return PlayerPrefs.GetFloat("Timer");
    }
    public void OnApplicationQuit()
    {
        SaveData();
    }
}
