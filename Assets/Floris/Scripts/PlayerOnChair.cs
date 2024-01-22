using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnChair : MonoBehaviour
{
    public RaycastHand handRay;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            handRay.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        handRay.enabled=false;
    }
}
