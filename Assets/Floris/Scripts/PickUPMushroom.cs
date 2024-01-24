using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUPMushroom : MonoBehaviour
{
    public bool lHandIn;
    public bool rHandIn;
    public GameObject lHand;
    public GameObject rHand;

    public GameObject realHandsR;
    public GameObject realHandsL;
    public GameObject fakeHandsR;
    public GameObject fakeHandsL;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHandL"))
        {
            realHandsL.SetActive(false);
            fakeHandsL.SetActive(true);
            lHand = other.gameObject;
            lHandIn = true;

        }
        else if (other.CompareTag("PlayerHandR"))
        {
            realHandsR.SetActive(true);
            fakeHandsR.SetActive(true);
            rHand = other.gameObject;
            rHandIn = true;
        }

    }
    private void Update()
    {
        if (lHandIn)
        {
            transform.position = lHand.transform.position;
            transform.rotation = lHand.transform.rotation;
        }
        if (rHandIn)
        {
            transform.position = rHand.transform.position;
            transform.rotation = rHand.transform.rotation;
        }
    }

}