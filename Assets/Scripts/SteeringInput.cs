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
        //steeringWheel.transform.localPosition = Vector3.zero;
       // steeringWheel.transform.localRotation = Quaternion.identity;
    }

    private void Update()
    {
        float steeringWheelRotationX = steeringWheel.transform.localRotation.x;
        float steeringWheelRotationY = steeringWheel.transform.localRotation.y;
        float steeringWheelRotationZ = steeringWheel.transform.localRotation.z;
        steeringWheel.transform.position = car.transform.position;
        steeringWheelRotationY = car.transform.localRotation.y;
        steeringWheelRotationX = car.transform.localRotation.x;
        /*if( steeringWheel.transform.localRotation.z >= 90)
        {
            steeringWheelRotationZ =
        }
        */
    }
   
    void LateUpdate()
    {
        
        if (inputGiver.leftHandOnWheelReadyToLetGo == true || inputGiver.rightHandOnWheelReadyToLetGo == true)
        {
            InputSteering();
            
        }

       
    }
    
    private void InputSteering()
    {
        
       
        float handRot = handL.localRotation.eulerAngles.z;
        float adjustedHandRotation = handRot - 90f;
        
        Vector3 currentRotation = transform.localEulerAngles;
        transform.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, adjustedHandRotation);

    }

    
}
