using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour
{
    #region variables

    public RaycastHandInGame inGameRaycast;
    public int checkPointIndex;
    public Timer timer;
    //public SafeLoad safeLoad;
    public Saveoad Saveoad;
    public TMP_Text recordTimer;
    public TMP_Text slowerTimer;
    public TMP_Text finish;
    public GameObject panelWin;
    public float checkPointTime;
    public float checkPointRecord;
    public float fiishTime;
    public bool firstRun = true;
    public bool hasFinished = false;
    public bool fired  = false;
    public CarMovement carMovement;
    public int minutes;
    public int seconds;
    public int miliSeconds;
   
    #endregion

    private void Start()
    {
           
        Saveoad.LoadData();
    }
    private void Update()
    {

       

        if (Saveoad.checkpointsNeeded.Count == 0)
        {
            panelWin.SetActive(true);
            hasFinished = true;
            HasFinishedCeck();
            //lapped all checkpoints
            inGameRaycast.enabled = true;
            carMovement.enabled = false;
          
        }

    }
    public void HasFinishedCeck()
    {
        if (hasFinished == true && fired == false)
        {
            // gebruik % om overgebleven float te pakken

            fiishTime = timer.currentTime;
            if (fiishTime < Saveoad.bestTime)
            {
                Debug.Log("Omdraaien");
                Saveoad.SaveDataBestTime();
            }
            minutes = Mathf.FloorToInt(fiishTime / 60);
            seconds = Mathf.FloorToInt(fiishTime % 60);
            miliSeconds = Mathf.FloorToInt(fiishTime * 1000);
            miliSeconds = miliSeconds % 1000;
            finish.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliSeconds);
            fired = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
           

            if (Saveoad.checkPointsPassed.Contains(checkPointIndex - 1) || Saveoad.checkpointsNeeded[0] == checkPointIndex)
            {
                checkPointTime = timer.currentTime;
                Saveoad.checkpointsNeeded.Remove(checkPointIndex);
                Saveoad.checkPointsPassed.Add(checkPointIndex);
                if (checkPointTime < checkPointRecord || firstRun == true)
                {
                    // ui als ui sneller is
                    float timeDifferenceFaster = checkPointRecord - checkPointTime;
                    recordTimer.text = $" - {timeDifferenceFaster:F2}";
                    checkPointRecord = checkPointTime;


                    
                    Saveoad.SaveDataCheckPoints();


                    recordTimer.enabled = true;
                    slowerTimer.enabled = false;
                    firstRun = false;
                    Saveoad.checkPointIdex++;
                    
                }

                else
                {
                    // ui als niet sneller is
                    Saveoad.checkPointIdex++;
                    UpdateSlowerTimer();
                    recordTimer.enabled = false;

                }
                
            }
        }

    }
        
    public void ButtonGoHome()
    {
        SceneManager.LoadScene(0);
    }
    
    private void UpdateSlowerTimer()
    {

        float recordTimer = checkPointRecord;
        float currentCheckPointTime = timer.currentTime;
        float timeDiffrence =  currentCheckPointTime - recordTimer;
        slowerTimer.text = $"+ : {timeDiffrence:F2}";
        slowerTimer.enabled = true;
    }

    
  
}

