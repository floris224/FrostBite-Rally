using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class SteeringInput : MonoBehaviour
{
    #region variable
    public Transform handL;
    public Transform handR;
    public SteeringWheelController inputGiver;
    public GameObject car;
    public GameObject steeringWheel;
    public float bothHandRot;
    #endregion
  
    void LateUpdate()
    {
       
        if (inputGiver.leftHandOnWheelReadyToLetGo == true || inputGiver.rightHandOnWheelReadyToLetGo == true)
        {
            InputSteering();
           

        }

       
    }
    
    private void InputSteering()
    {
        
       if(inputGiver.leftHandOnWheelReadyToLetGo == false)
       {
            float handRotR = handR.localRotation.eulerAngles.z;
            transform.localRotation = Quaternion.Euler(0, 0, handRotR);
        }
       if(inputGiver.rightHandOnWheelReadyToLetGo == false)
       {
            float handRotL = handL.localRotation.eulerAngles.z;
            transform.localRotation = Quaternion.Euler(0, 0, handRotL);

            
       }
       if(inputGiver.leftHandOnWheelReadyToLetGo== true && inputGiver.rightHandOnWheelReadyToLetGo == true)
       {
            float handRotL = handL.localRotation.eulerAngles.z;

            //Testing
            float handRotR = -handR.localRotation.eulerAngles.z;
            float bothHandRotation = handRotL - handRotR;
           
            transform.localRotation = Quaternion.Euler(0, 0, bothHandRotation);
       }
        
    }

    
}
