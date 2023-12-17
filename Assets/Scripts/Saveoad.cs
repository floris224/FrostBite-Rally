using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Saveoad : MonoBehaviour
{
    public CheckPoints[] checkPoints;
    public int checkPointIdex;
    public float loadTime;
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
    public float LoadData()
    {
        loadTime = PlayerPrefs.GetFloat("Time");
        if(loadTime != 0)
        {
            checkPoints[checkPointIdex].checkPointRecord = loadTime;
            Debug.Log($"Loaded Time: {checkPoints[checkPointIdex].checkPointTime} from {loadTime}");
        }
        else
        {
            Debug.Log("TisBedTijd");
        }
        
        
        return loadTime;

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
