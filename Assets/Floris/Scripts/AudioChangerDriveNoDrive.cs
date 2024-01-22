using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioChangerDriveNoDrive : MonoBehaviour
{
    
    public AudioSource audioSourceDriveAndStill;
    public AudioSource audiosourceDrive;
    public CarMovement carController;
    public OnTriggerEnerStartCar startCar;

    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.5f && startCar.isCarStarted == true )
        {
            audioSourceDriveAndStill.enabled = false;
            audiosourceDrive.enabled = true;
            
        }
        
        else if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) < 0.5f && startCar.isCarStarted == true)
        {

            audioSourceDriveAndStill.enabled = true;
            audiosourceDrive.enabled = false;
        }
    }
}
