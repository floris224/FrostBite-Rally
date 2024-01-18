using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChangerDriveNoDrive : MonoBehaviour
{
    public List<AudioClip> audioclipsDriveandStandStill;
    public AudioSource audioSourceDriveAndStill;
    public CarMovement carController;


    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if(carController.gasInput == 0)
        {
            audioSourceDriveAndStill.clip = audioclipsDriveandStandStill[0];
        }
        else if (carController.gasInput ==1)
        {
            
            audioSourceDriveAndStill.clip = audioclipsDriveandStandStill[1];
        }
    }
}
