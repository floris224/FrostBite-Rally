using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SteeringInput : MonoBehaviour
{
    public Transform handL;
    public SteeringWheelController inputGiver;
    public GameObject car;
    public GameObject steeringWheel;
    // Start is called before the first frame update
    void Start()
    {
        steeringWheel.transform.localPosition = Vector3.zero;
        steeringWheel.transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //gameObject.transform.localRotation = car.transform.localRotation;
        InputSteering();
       
      
        if (inputGiver.numberOfHandsOnWheel > 0)
        {
            InputSteering();
            handL.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        steeringWheel.transform.parent = car.transform;
    }
    
    private void InputSteering()
    {
        // Quaternion handRotation = handL.rotation;
        // float newZRot = handRotation.eulerAngles.z;
        //transform.rotation = Quaternion.Euler(0,car.transform.rotation.y,newZRot);

       
        float handRot = handL.localRotation.eulerAngles.z;
        float adjustedHandRotation = handRot - 90f;
        if(handRot >= 50)
        {
            handRot = 90;
        }
        if(handRot<= -50)
        {
            handRot = -50;
        }
        Vector3 currentRotation = transform.localEulerAngles;
        transform.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, adjustedHandRotation);

    }

    
}
