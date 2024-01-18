using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRaceTimer : MonoBehaviour
{
    public OnTriggerEnerStartCar startCarSound;
    public GameObject redLicht;
    public GameObject greenLicht;
    public SteeringWheelController steeringInput;
    public float timer;
    public Timer timerPlayer;

    public AudioClip startSounds;
    public AudioSource startSoundAudioSource;
    public bool stopSound = false;
    // Start is called before the first frame update
    void Start()
    {

        

       
    }

    // Update is called once per frame
    void Update()
    {
        if (startCarSound.isCarStarted == true && steeringInput.rightHandOnWheel && stopSound == false || startCarSound.isCarStarted == true && steeringInput.leftHandOnWheel && stopSound == false)
        {
            startSoundAudioSource.PlayOneShot(startSounds);
            stopSound = true;

        }
        if(stopSound == true)
        {
            timer += Time.deltaTime;
        }
        if (timer > 5)
        {
            redLicht.SetActive(false);
            greenLicht.SetActive(true);
            timerPlayer.enabled = true;
            

        }   
    }
}
