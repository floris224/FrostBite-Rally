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

        checkPointRecord = Saveoad.loadTime;
        Debug.Log(checkPointRecord);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            checkPointTime = timer.currentTime;
           
           
           
            if (checkPointTime < checkPointRecord|| firstRun)
            {
                // ui als ui sneller is
                checkPointRecord = checkPointTime;
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
    private void UpdateSlowerTimer()
    {
        
        float recordTimer = Saveoad.GetData();
        float currentCheckPointTime = timer.currentTime;
        float timeDiffrence =  currentCheckPointTime - recordTimer;
        slowerTimer.text = $"Slower: {timeDiffrence:F2} seconds";
        slowerTimer.enabled = true;
    }

}

