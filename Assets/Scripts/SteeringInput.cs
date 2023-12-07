using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SteeringInput : MonoBehaviour
{
    public Transform handL;
    public SteeringWheelController inputGiver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputGiver.numberOfHandsOnWheel > 0)
        {
            InputSteering();
        
        }
       
    }
    private void InputSteering()
    {
        Quaternion handRotation = handL.rotation;

        float newZRot = handRotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0,0,newZRot);
       
    }
}
