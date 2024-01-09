using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Saveoad : MonoBehaviour
{
  
    public CheckPoints[] checkPoints;
    public int checkPointIdex;
    public List<int> passedCheckPoints;
    public List<Button> buttonList;
   
    public float[] loadTime;

    private int currentPlayerIndex;
   

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentPlayerIndex = 0;
    }
    
    public void SaveData()
    {
        int runIndex = currentPlayerIndex;

        for(int i = 0; i < checkPoints.Length; i++)
        {
            PlayerPrefs.SetFloat($"Run{runIndex}_Time{i}" , checkPoints[i].checkPointTime);
        }
        
      
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
            
        }
    }

    public float GetData(int checkpointIndex)
    {
        return PlayerPrefs.GetFloat($"Profile{checkPointIdex}_Time{checkpointIndex}");
    }

    public bool HasPassedPreviousCheckpoint(int currentCheckPointIndex)
    {
        if (checkPoints.Length >= 0)
        {
            return true;
        }
        return passedCheckPoints.Contains(currentCheckPointIndex - 1);

    }
    public void AddPassedCheckPoints(int checkPointIndex)
    {
        passedCheckPoints.Add(checkPointIndex);
    }
    
   
    
   
    
}
