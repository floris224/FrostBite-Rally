using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public string checkPoint;
    public Timer timer;
    public SafeLoad safeLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            float checkPointTime = timer.currentTime;
            bool isRecordTimer = safeLoad.SaveCheckPointTime(checkPoint,checkPointTime);
            if (isRecordTimer)
            {
                // ui als ui sneller is 

            }
            else
            {
                // ui als niet sneller is
            }
        }
        
    }
}
