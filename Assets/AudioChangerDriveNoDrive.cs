using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChangerDriveNoDrive : MonoBehaviour
{
    public List<AudioClip> audioclipsDriveandStandStill;
    public AudioSource audioSourceDriveAndStill;

    public Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPos == transform.position)
        {
            audioSourceDriveAndStill.clip = audioclipsDriveandStandStill[0];
        }
        else
        {
            currentPos = transform.position;
            audioSourceDriveAndStill.clip = audioclipsDriveandStandStill[1];
        }
    }
}
