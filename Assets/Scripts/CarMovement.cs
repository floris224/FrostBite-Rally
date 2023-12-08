using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class CarMovement : MonoBehaviour
{

    public GameObject steeringWheel;


    private Rigidbody rb;
    public WheelColliders colliders;
    public WheelMeshs wheelMesh;
    
    public InputActionAsset asset;
    public InputAction driveInputfw;
    public InputAction rotationInput;
    public InputAction gasInputs;

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

    public SteeringWheelController controller;
    private void Awake()
    {

        driveInputfw = asset.FindAction("DriveForwards");
        rotationInput = asset.FindAction("Turn");
       
    }
    private void OnEnable()
    {
        driveInputfw.Enable();
        rotationInput.Enable();
      
    }
    private void OnDisable()
    {
        driveInputfw.Disable();
        rotationInput.Disable();
        
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
        
        steeringInput = rotationInput.ReadValue<float>();

        driftAngle = Vector3.Angle(transform.forward, rb.velocity);
        if (driftAngle < 120)
        {
            if (gasInput < 0)
            {
                brakeInput = Mathf.Abs(gasInput);
                gasInput = 0;

            }
            else
            {
                brakeInput = 0;
            }
        }
        else
        {
            brakeInput = 0;
        }
        
         
    }
    void FixedUpdate()
    {
        speed = rb.velocity.magnitude;
        checkInput();
        if (controller.numberOfHandsOnWheel > 0 &&  OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            
            gasInput = 1;
            
            ApplyHorsePower();
        }
        else
        {
            gasInput = 0;
        }

        if (controller.numberOfHandsOnWheel > 0 && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            brakeInput = MathF.Abs(gasInput);
            gasInput = 0;
            ApplyBrakes();
        }
        else
        {
            brakeInput = 0;
        }
        
        ApplyUpdateWheels();
       
        ApplySteering();
        
    }
    void ApplyHorsePower()
    {
            colliders.RRWheel.motorTorque = horsePower * gasInput;
            colliders.RLWheel.motorTorque = horsePower * gasInput;
            colliders.fRWheel.motorTorque = horsePower * gasInput;
            colliders.fLWheel.motorTorque = horsePower * gasInput;
    }
    public void ApplySteering()
    {
             
        float steeringWheelRotation = steeringWheel.transform.localRotation.eulerAngles.z;
        
        /*
         if (steeringWheelRotation > 180)
         {
                steeringWheelRotation -= 360;
         }
        */


            float normalizedSteeringInput = steeringWheelRotation / 90f;
            steeringInput = Mathf.Clamp(normalizedSteeringInput, -1f, 1f);
          

            float steeringAngle = steeringInput * steeringCurve.Evaluate(speed)/ 3;
            colliders.fRWheel.steerAngle = -steeringAngle;
            colliders.fLWheel.steerAngle = -steeringAngle;
        
       
    }

    void ApplyBrakes()
    {
        
        colliders.fLWheel.brakeTorque = brakeTorgue * brakeInput * 0.9f;
        colliders.fRWheel.brakeTorque = brakeTorgue * brakeInput * 0.9f;
        colliders.RRWheel.brakeTorque = brakeTorgue * brakeInput * 0.1f;
        colliders.RLWheel.brakeTorque = brakeTorgue * brakeInput * 0.1f;
       
    }
    void ApplyUpdateWheels()
    {
        UpdateWheel(colliders.fRWheel,wheelMesh.fRWheel);
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

        //Mathf.Clamp(quaternion.y, 315, 45);
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