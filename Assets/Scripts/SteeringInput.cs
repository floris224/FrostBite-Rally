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
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //gameObject.transform.localRotation = car.transform.localRotation;
        InputSteering();
        if (inputGiver.numberOfHandsOnWheel > 0)
        {
            InputSteering();
        
        }
        
       
    }
    
    private void InputSteering()
    {
       // Quaternion handRotation = handL.rotation;
       // float newZRot = handRotation.eulerAngles.z;
        //transform.rotation = Quaternion.Euler(0,car.transform.rotation.y,newZRot);

        float handRot = handL.localEulerAngles.z;
        Vector3 currentRotation = transform.localEulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, handRot);
    }

    
}
