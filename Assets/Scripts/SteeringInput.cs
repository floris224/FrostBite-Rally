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

    private void Update()
    {
       
        steeringWheel.transform.position = car.transform.position;
        
        
    }
   
    void LateUpdate()
    {
        InputSteering();
        if (inputGiver.leftHandOnWheelReadyToLetGo == true || inputGiver.rightHandOnWheelReadyToLetGo == true)
        {
           // InputSteering();
            
        }

       
    }
    
    private void InputSteering()
    {
        
       
        float handRot = handL.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(0,0, handRot);

    }

    
}
