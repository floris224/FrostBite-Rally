using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDidTheTeleport : MonoBehaviour
{
    public bool didTeleport;
    public GameObject tutorialTeleport;
    private void OnTriggerEnter(Collider other)
    {
        if(didTeleport  != true && other.tag == "Player")
        {
            tutorialTeleport.SetActive(false);
            didTeleport = true;
        }
    }
}
