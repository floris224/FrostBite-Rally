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
            fiishTime = timer.currentTime;
            int minutes = Mathf.FloorToInt(fiishTime / 60);
            int seconds = Mathf.FloorToInt(fiishTime % 60);
            finish.text = string.Format("{00:00}:{1:00}", minutes, seconds);
            fired = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            checkPointTime = timer.currentTime;

            if (Saveoad.checkPointsPassed.Contains(checkPointIndex -1) || Saveoad.checkPointIdex == 0)
            {
                Saveoad.checkpointsNeeded.Remove(checkPointIndex);
                Saveoad.checkPointsPassed.Add(checkPointIndex);
                if (checkPointTime < checkPointRecord || firstRun)
                {
                    // ui als ui sneller is
                    checkPointRecord = checkPointTime;


                    
                    recordTimer.text = timer.currentTime + "New Record";
                    Saveoad.SaveData();


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
        slowerTimer.text = $"Slower: {timeDiffrence:F2} seconds";
        slowerTimer.enabled = true;
    }

    
  
}

