using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SteeringInput : MonoBehaviour
{
    public Transform handL;
    public SteeringWheelController inputGiver;
    public GameObject car;
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
        Quaternion handRotation = handL.rotation;

        float newZRot = handRotation.eulerAngles.z;
        
        //clamp werked niet 
        //Mathf.Clamp(handRotation.eulerAngles.z, 315, 45);
        transform.rotation = Quaternion.Euler(0,car.transform.rotation.y,newZRot);
        
    }

    
}
