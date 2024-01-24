using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveLoadMAp2 : MonoBehaviour
{

    public CheckPoints[] checkPoints;
    public int checkPointIdex;
    public CheckPoints checkPointsScript;
    

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
            foreach (CheckPoints checkPoint in checkPoints)
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

        for (int i = 0; i < checkPoints.Length; i++)
        {
            PlayerPrefs.SetFloat("Map2", checkPoints[i].checkPointTime);
        }

    }
    
    public void SaveDataBestTime()
    {
        PlayerPrefs.SetFloat("BestTime2", checkPointsScript.fiishTime);

        Debug.Log("new Bestime" + bestTime);
    }
  
    public void LoadData()
    {

        loadTime = new float[checkPoints.Length];

        for (int i = 0; i < checkPoints.Length; i++)
        {
            loadTime[i] = PlayerPrefs.GetFloat("Map2", checkPoints[i].checkPointTime);
            if (loadTime[i] != 0)
            {
                checkPoints[i].checkPointRecord = loadTime[i];

            }
            else
            {
                checkPoints[i].checkPointRecord = float.MaxValue;
            }

        }

        
        if (PlayerPrefs.HasKey("BestTime2"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime2");
        }
        else
        {
            bestTime = float.MaxValue;
        }
        

    }

    public float GetData(int checkpointIndex)
    {
        return PlayerPrefs.GetFloat("Map2");
    }

    public void DeletaAllDataPrefs()
    {
        PlayerPrefs.DeleteAll();
    }






}


