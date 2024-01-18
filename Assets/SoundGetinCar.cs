using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGetinCar : MonoBehaviour
{
    public AudioSource audioSourceDoor;
    public AudioClip doorClose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSourceDoor.PlayOneShot(doorClose);
        }
    }
}
