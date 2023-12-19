using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrows : MonoBehaviour
{
    public GameObject arrowRight;
    public GameObject arrowLittleRight;
    public GameObject arrowLeft;
    public GameObject arrowLittleLeft;
    public GameObject arrowStrait;
    public GameObject arrowUturnRight;
    public GameObject arrowUturnLeft;

    public void OnTriggerEnter(Collider other)
    {
        if (tag == "turnRight")
        {
            arrowRight.SetActive(true);
            
        }
        if (tag == "littleRight")
        {
            arrowLittleLeft.SetActive(true);
            arrowLittleRight.SetActive(true);
        }
        

    }
    public void OnTriggerExit(Collider other)
    {
        if (tag == "turnRight")
        {
            arrowRight.SetActive(false);
            
        }
        if (tag == "littleRight")
        {
            arrowLittleLeft.SetActive(false);
            arrowLittleRight.SetActive(false);
        }
    }

}
