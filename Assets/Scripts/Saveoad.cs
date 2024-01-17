using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Saveoad : MonoBehaviour
{
  
    public CheckPoints[] checkPoints;
    public int checkPointIdex;
    public CheckPoints checkPointsScript;
    public List<Button> buttonList;
   
    public float[] loadTime;

    private int currentPlayerIndex;
    public List<int> checkpointsNeeded;
    public List<int> checkPointsPassed;
    public Timer timer;
    public float bestTime;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            DeletaAllDataPrefs();
            Debug.Log("DeletedData");
           foreach(CheckPoints checkPoint in checkPoints)
           {
                checkPoint.firstRun = true;
                break;
           }
        }

    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentPlayerIndex = 0;
    }
    
    public void SaveDataCheckPoints()
    {
        int runIndex = currentPlayerIndex;

        for(int i = 0; i < checkPoints.Length; i++)
        {
            PlayerPrefs.SetFloat($"Run{runIndex}_Time{i}" , checkPoints[i].checkPointTime);
        }

    }
    public void SaveDataBestTime()
    {
        PlayerPrefs.SetFloat("BestTime", checkPointsScript.fiishTime);

        Debug.Log("new Bestime" + bestTime);
    }
    public void LoadData()
    {
       
        loadTime = new float[checkPoints.Length];
       
        for(int i = 0; i < checkPoints.Length; i++)
        {
            loadTime[i] = PlayerPrefs.GetFloat($"Run{currentPlayerIndex}_Time{i}");
            if (loadTime[i] != 0)
            {
                checkPoints[i].checkPointRecord = loadTime[i];

            }
            else
            {
                checkPoints[i].checkPointRecord = float.MaxValue;
            }
            
        }
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
        }
        else
        {
            bestTime = float.MaxValue;
        }
        
    }

    public float GetData(int checkpointIndex)
    {
        return PlayerPrefs.GetFloat($"Profile{checkPointIdex}_Time{checkpointIndex}");
    }
   
    public void DeletaAllDataPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    
   
    
   
    
}
