using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour
{
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
    public List<int> checkpointsNeeded; 
    private void Start()
    {
           
        Saveoad.LoadData();
    }
    private void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            checkPointTime = timer.currentTime;

            if (checkpointsNeeded.Contains(checkPointIndex))
            {
                checkpointsNeeded.Remove(checkPointIndex);
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
                    if (checkpointsNeeded.Count == 0)
                    {
                        panelWin.SetActive(true);
                        fiishTime = timer.currentTime;
                        //lapped all checkpoints
                        finish.text = $": {fiishTime:F4} seconds";

                    }
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
        slowerTimer.text = $"Slower: {timeDiffrence:F4} seconds";
        slowerTimer.enabled = true;
    }

  
}

