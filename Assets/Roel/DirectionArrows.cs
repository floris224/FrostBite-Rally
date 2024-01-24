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
    public bool hasPlayed;
    public List<AudioClip> diffrentClips;
    public List<AudioSource> audioSources;
    public void OnTriggerEnter(Collider other)
    {
        if (tag == "turnRight")
        {
            if (!hasPlayed)
            {
                audioSources[0].PlayOneShot(diffrentClips[7]);
                hasPlayed = true;
               
            }
            arrowRight.SetActive(true);

        }
        if (tag == "LongLeft")
        {
            if (!hasPlayed)
            {
                audioSources[0].PlayOneShot(diffrentClips[3]);
                hasPlayed = true;
            }
            arrowLeft.SetActive(true);
        }
        if (tag == "LongRight")
        {
            if (!hasPlayed)
            {
                audioSources[0].PlayOneShot(diffrentClips[4]);
                hasPlayed = true;
            }
            arrowRight.SetActive(true);
        }
        if (tag == "littleRight")
        {
            if (!hasPlayed)
            {
                audioSources[0].PlayOneShot(diffrentClips[5]);
                hasPlayed = true;
            }
            arrowLittleLeft.SetActive(true);
            arrowLittleRight.SetActive(true);
        }
        if( tag == "goStraight")
        {
            if (!hasPlayed)
            {
                audioSources[0].PlayOneShot(diffrentClips[8]);
                hasPlayed = true;
            }
  
            arrowStrait.SetActive(true);
        }
        if(tag == "uTurnLeft")
        {
            if (!hasPlayed)
            {
                audioSources[0].PlayOneShot(diffrentClips[0]);
                hasPlayed = true;
            }
            arrowUturnLeft.SetActive(true);
        }
        if (tag == "uTurnRight")
        {
            if (!hasPlayed)
            {
                audioSources[0].PlayOneShot(diffrentClips[1]);
                hasPlayed = true;
            }
           
            arrowUturnRight.SetActive(true);
        }

        if (tag == "turnLeft")
        {
            if (!hasPlayed)
            {
                
                audioSources[0].PlayOneShot(diffrentClips[6]);
                hasPlayed = true;
            }
           
            arrowLeft.SetActive(true);
        }
        

    }
    public void OnTriggerExit(Collider other)
    {
        if (tag == "LongLeft")
        {
            hasPlayed = false;
            arrowLeft.SetActive(false);
        }
        if (tag == "LongRight")
        {
            hasPlayed=false;
            arrowRight.SetActive(false);
        }
        if (tag == "uTurnRight")
        {
            hasPlayed = false;
            arrowUturnRight.SetActive(false);
        }
        if (tag == "turnRight")
        {
            hasPlayed = false;
            arrowRight.SetActive(false);
            
        }
        if (tag == "littleRight")
        {
            hasPlayed = false;
            arrowLittleLeft.SetActive(false);
            arrowLittleRight.SetActive(false);
        }
        if (tag == "goStraight")
        {
            hasPlayed = false;
            arrowStrait.SetActive(false);
        }
        if (tag == "uTurnLeft")
        {
            hasPlayed = false;
            arrowUturnLeft.SetActive(false);
        }
        if (tag == "turnLeft")
        {
            hasPlayed = false;
            arrowLeft.SetActive(false);
        }
    }

}
