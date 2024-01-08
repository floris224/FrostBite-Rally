using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Saveoad : MonoBehaviour
{
    public GameObject[] placementLeaderBoard;
    public CheckPoints[] checkPoints;
    public int checkPointIdex;
    public List<int> passedCheckPoints;
    
    public List<float> leaderBoardTimes = new List<float>();

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
    public void CheckLeaderBoard()
    {

    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("Time" + checkPointIdex, checkPoints[checkPointIdex].checkPointTime);
      
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
             
            }
           
        }
       
        
        
       

    }
    public float GetData()
    {
        return PlayerPrefs.GetFloat("Timer");
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
    public void OnApplicationQuit()
    {
        SaveData();
    }

    public void UpdateLeaderBoard(float playerTime)
    {

        leaderBoardTimes.Add(playerTime);
        leaderBoardTimes.Sort();
        leaderBoardTimes.Reverse();
        
    }
    private void SaveLeaderBoard()
    {
        for (int i = 0; i < Mathf.Min(leaderBoardTimes.Count, placementLeaderBoard.Length); i++)
        {
            PlayerPrefs.SetFloat("LeaderBoardTime" + i, leaderBoardTimes[i]);
        }
    }
    public void LoadLeaderBoardTime()
    {
      // needs to be pressed with a button in vr and there a 6 places )
    }
}
