using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CarMovement : MonoBehaviour
{

    public GameObject steeringWheel;


    private Rigidbody rb;
    public WheelColliders colliders;
    public WheelMeshs wheelMesh;
    
    public InputActionAsset asset;
    public InputAction driveInputfw;
    public InputAction rotationInput;
    public InputAction brakeInputs;

    public bool brake;

    public float horsePower;
    public float gasInput;
    public float steeringInput;
    public float gasinputVR;
    public float brakeTorqueF;
    public float brakeTorqueR;
    public float brakeTorgue;
    public float brakeInput;
    private float speed;
    //public float driftAngle;
    public float maxRotation;
    public AnimationCurve steeringCurve;
    public GameObject downForce;
    public SteeringWheelController controller;
    public StartRaceTimer raceTimer;

  
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void checkInput()
    {
        
        brakeInput = brakeInputs.ReadValue<float>();
        steeringInput = rotationInput.ReadValue<float>();
      
        
        
         
    }
    void FixedUpdate()
    {
        rb.AddForce(-transform.up  *2, ForceMode.Force);
        speed = rb.velocity.magnitude;
        checkInput();
        if (controller.leftHandOnWheelReadyToLetGo == true || controller.rightHandOnWheelReadyToLetGo == true)
        {
            if(raceTimer.readyToDrive == true)
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.5f)
                {
                    gasInput = 1;
                   
                    ApplyHorsePowerForwards();
                }
                else
                {
                  
                    gasInput = 0;
                }
            }
           

            
        }
        

        ApplyUpdateWheels();

        ApplySteering();
        
         if (controller.leftHandOnWheelReadyToLetGo == true || controller.rightHandOnWheelReadyToLetGo == true)
         {
            if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.5f)
            {
                brakeInput = 1;
                ApplyBrakes();
                
            }
            else
            {

                ReleaseBrake();
                
            }
         }

        if (controller.leftHandOnWheelReadyToLetGo == true || controller.rightHandOnWheelReadyToLetGo == true)
        {
            if(raceTimer.readyToDrive == true)
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0.5f)
                {
                    gasInput = -1;
                    ApplyHorsePowerBack();
                }
            }
          
        }




    }
        
        void ApplyHorsePowerForwards()
        {
            rb.AddForce(transform.forward * horsePower);
            colliders.RRWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.RLWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.fRWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.fLWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
        }

        void ApplyHorsePowerBack()
        {
            rb.AddForce(-transform.forward * horsePower);
            colliders.RRWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.RLWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.fRWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.fLWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
        }
        
        void ApplySteering()
        {
             float steeringWheelRotation = steeringWheel.transform.localEulerAngles.z;

        
            if (steeringWheelRotation > 230)
            {
             steeringWheelRotation -= 360f;
            }
        
            float minSteeringAngle = -70f;
            float maxSteeringAngle = 70f;
            steeringWheelRotation = Mathf.Clamp(steeringWheelRotation, minSteeringAngle, maxSteeringAngle);

            float normalizedSteeringInput = Mathf.InverseLerp(-70,70f, steeringWheelRotation) * 2f - 1f;
            float steeringInput = Mathf.Clamp(normalizedSteeringInput, -1f, 1f);



            float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);


        /*
            float minSteeringAngle = -45;
            float maxSteeringAngle = 45;

            if (steeringAngle <= minSteeringAngle)
            {
                steeringAngle = minSteeringAngle;
            }
            if (steeringAngle >= maxSteeringAngle)
            {
                steeringAngle = maxSteeringAngle;
            }
        */

            colliders.fRWheel.steerAngle = -steeringAngle;
            colliders.fLWheel.steerAngle = -steeringAngle;

        }


        void ReleaseBrake()
        {
            colliders.fLWheel.brakeTorque = 0;
            colliders.fRWheel.brakeTorque = 0;
            colliders.RRWheel.brakeTorque = 0;
            colliders.RLWheel.brakeTorque = 0;
        }

        void ApplyBrakes()
        {

            colliders.fLWheel.brakeTorque = brakeTorgue * brakeInput * brakeTorqueF;
            colliders.fRWheel.brakeTorque = brakeTorgue * brakeInput * brakeTorqueF;
            colliders.RRWheel.brakeTorque = brakeTorgue * brakeInput * brakeTorqueR;
            colliders.RLWheel.brakeTorque = brakeTorgue * brakeInput * brakeTorqueR;
            
        }
        void ApplyUpdateWheels()
        {
            UpdateWheel(colliders.fRWheel, wheelMesh.fRWheel);
            UpdateWheel(colliders.fLWheel, wheelMesh.fLWheel);
            UpdateWheel(colliders.RLWheel, wheelMesh.RLWheel);
            UpdateWheel(colliders.RRWheel, wheelMesh.RRWheel);
        }
        void UpdateWheel(WheelCollider collider, MeshRenderer wheelMesh)
        {
            Quaternion quaternion;
            Vector3 position;
            collider.GetWorldPose(out position, out quaternion);

            wheelMesh.transform.position = position;
            wheelMesh.transform.rotation = quaternion;


        }
    
}

[System.Serializable]
public class WheelColliders
{
    public WheelCollider fRWheel;
    public WheelCollider fLWheel;
    public WheelCollider RRWheel;
    public WheelCollider RLWheel;

}
[System.Serializable]
public class WheelMeshs
{
    public MeshRenderer fRWheel;
    public MeshRenderer fLWheel;
    public MeshRenderer RRWheel;
    public MeshRenderer RLWheel;

}