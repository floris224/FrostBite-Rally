using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoints : MonoBehaviour
{
    public int checkPointIndex;
    public Timer timer;
    //public SafeLoad safeLoad;
    public Saveoad Saveoad;
    public TMP_Text recordTimer;
    public TMP_Text slowerTimer;
   
    public float checkPointTime;
    public float checkPointRecord;
    public bool firstRun = true;

    private void Start()
    {
        
    }
    private void Update()
    {
        Saveoad.loadTime[checkPointIndex] = checkPointRecord;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            checkPointTime = timer.currentTime;
            Debug.Log("Made it");

            if (Saveoad.HasPassedPreviousCheckpoint(checkPointIndex))
            {
                if (checkPointTime < checkPointRecord || firstRun)
                {
                    // ui als ui sneller is
                    checkPointRecord = checkPointTime;
                    Saveoad.AddPassedCheckPoints(checkPointIndex);
                    Saveoad.SaveData();
                    recordTimer.text = Saveoad.GetData() + "New Record";
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
    
    private void UpdateSlowerTimer()
    {
        
        float recordTimer = Saveoad.GetData();
        float currentCheckPointTime = timer.currentTime;
        float timeDiffrence =  recordTimer - currentCheckPointTime;
        slowerTimer.text = $"Slower: {timeDiffrence:F2} seconds";
        slowerTimer.enabled = true;
    }

}

