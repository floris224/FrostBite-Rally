using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutVrOn : MonoBehaviour
{
    public bool startIsPressed;
    public GameObject putVrOn;
    public GameObject mainMenu;
    public GameObject fakeHandsR;
    public GameObject fakeHandsL;
    public GameObject realHandsR;
    public GameObject realHandsL;

    private void OnTriggerEnter(Collider other)
    {
        if(startIsPressed == true && other.gameObject.tag == "PlayerHandL")
        {
            
            fakeHandsL.SetActive(true);
            
            realHandsL.SetActive(false);
            transform.parent = other.transform;
            
        }
        else if(startIsPressed == true && other.gameObject.tag == "PlayerHandR")
        {
            fakeHandsR.SetActive(true);
            realHandsR.SetActive(false);
            transform.parent = other.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
