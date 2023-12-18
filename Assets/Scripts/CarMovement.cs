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
   
    public float brakeTorgue;
    public float brakeInput;
    public float speed;
    public float driftAngle;
    public float maxRotation;
    public AnimationCurve steeringCurve;
    public GameObject downForce;
    public SteeringWheelController controller;
    private void Awake()
    {

        driveInputfw = asset.FindAction("DriveForwards");
        rotationInput = asset.FindAction("Turn");
        brakeInputs = asset.FindAction("Brake");
       
    }
    private void OnEnable()
    {
        driveInputfw.Enable();
        rotationInput.Enable();
        brakeInputs.Enable();
    }
    private void OnDisable()
    {
        driveInputfw.Disable();
        rotationInput.Disable();
        brakeInputs.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void checkInput()
    {
        gasInput = driveInputfw.ReadValue<float>();
        brakeInput = brakeInputs.ReadValue<float>();
        steeringInput = rotationInput.ReadValue<float>();
        driftAngle = Vector3.Angle(transform.forward, rb.velocity);
        
        
         
    }
    void FixedUpdate()
    {
        rb.AddForce(-transform.up, ForceMode.Force);
        speed = rb.velocity.magnitude;
        checkInput();
        if (controller.leftHandOnWheelReadyToLetGo == true || controller.rightHandOnWheelReadyToLetGo == true)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.5f)
            {
                gasInput = 1;
                Debug.LogError("test");
                ApplyHorsePowerForwards();
            }
            else
            {
                gasInput = 0;
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
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0.5f)
            {
                gasInput = -1;
                ApplyHorsePowerBack();
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

            if (steeringWheelRotation > 180f)
            {
             steeringWheelRotation -= 360f;
            }
        // steeringWheelRotation = Mathf.Repeat(steeringWheelRotation, 360f);
        float minSteeringAngle = -60f;
            float maxSteeringAngle = 60f;
            steeringWheelRotation = Mathf.Clamp(steeringWheelRotation, minSteeringAngle, maxSteeringAngle);

            float normalizedSteeringInput = Mathf.InverseLerp(-60f,60f, steeringWheelRotation) * 2f - 1f;
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

            colliders.fLWheel.brakeTorque = brakeTorgue * brakeInput * 0.8f;
            colliders.fRWheel.brakeTorque = brakeTorgue * brakeInput * 0.8f;
            colliders.RRWheel.brakeTorque = brakeTorgue * brakeInput * 0.2f;
            colliders.RLWheel.brakeTorque = brakeTorgue * brakeInput * 0.2f;
            
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