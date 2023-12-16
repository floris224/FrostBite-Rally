using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoints : MonoBehaviour
{
    public int checkPointIndex;
    public Timer timer;
    public SafeLoad safeLoad;

    public TMP_Text recordTimer;
    public TMP_Text slowerTimer;
    public float timeDifferenceToFastest;
    public float checkPointTime;

    private void Start()
    {

        LoadCheckpointTimer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log($"Entered checkpoint with index: {checkPointIndex}");
            checkPointTime = timer.currentTime;
            bool isRecordTimer = SaveCheckpointTimer();
            if (isRecordTimer)
            {
                // ui als ui sneller is
                recordTimer.text = safeLoad.GetCheckPointTime(checkPointIndex) + "New Record";
                recordTimer.enabled = true;
                slowerTimer.enabled = false;

            }
            else
            {
                // ui als niet sneller is
                UpdateSlowerTimer();
                recordTimer.enabled = false;
            }
        }
        
    }
    private void UpdateSlowerTimer()
    {
        timeDifferenceToFastest = checkPointTime;
        float recordTimer = safeLoad.GetCheckPointTime(checkPointIndex);
        float currentCheckPointTime = timer.currentTime;
        float timeDiffrence =  currentCheckPointTime - recordTimer;
        slowerTimer.text = $"Slower: {timeDiffrence:F2} seconds";
        slowerTimer.enabled = true;
    }
    private bool SaveCheckpointTimer()
    {
       
        return safeLoad.SaveCheckPointTime(checkPointIndex, checkPointTime);
    }

    private void LoadCheckpointTimer()
    {
        checkPointTime = safeLoad.GetCheckPointTime(checkPointIndex);
        Debug.Log($"Loaded checkpoint time for index {checkPointIndex}: {checkPointTime}");
    }
}

