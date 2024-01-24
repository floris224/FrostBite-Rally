using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnerStartCar : MonoBehaviour
{
    public AudioClip startCar;
    public AudioSource startCarAudioSource;
    public bool isCarStarted = false;
    public StartRaceTimer startRaceTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCarStarted)
        {
            if (other.CompareTag("PlayerHandR"))
            {
                startCarAudioSource.PlayOneShot(startCar);
                isCarStarted = true;

            }
        }
     
    }
    private void Update()
    {
        if (isCarStarted)
        {
            startRaceTimer.enabled = true;
        }
    }
}
