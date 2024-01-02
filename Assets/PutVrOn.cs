using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutVrOn : MonoBehaviour
{
    public bool startIsPressed, leftHandIn, rightHandIn;
    public GameObject putVrOn;
    public GameObject mainMenu;
    public GameObject fakeHandsR;
    public GameObject fakeHandsL;
    public GameObject realHandsR;
    public GameObject realHandsL;
    public GameObject hand1;
    public GameObject hand2;

    private void OnTriggerEnter(Collider other)
    {
      
        if(startIsPressed == true && other.CompareTag("PlayerHandL"))
        {
       
            fakeHandsL.SetActive(true);
            leftHandIn = true;
            realHandsL.SetActive(false);
            hand1 = other.gameObject;
            
        }
        else if(startIsPressed == true && other.CompareTag("PlayerHandR"))
        {
           
            fakeHandsR.SetActive(true);
            rightHandIn = true;
            realHandsR.SetActive(false);
            hand2 = other.gameObject;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(leftHandIn)
        {
            transform.position = hand1.transform.position;
            transform.rotation = hand1.transform.rotation;
        }
        if (rightHandIn)
        {
            transform.position = hand2.transform.position;
            transform.rotation = hand2.transform.rotation;
        }
    }
}
