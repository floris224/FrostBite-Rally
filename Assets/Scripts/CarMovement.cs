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
        speed = rb.velocity.magnitude  * 5;
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
            rb.AddForce(transform.forward * horsePower);
            colliders.RRWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.RLWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.fRWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
            colliders.fLWheel.motorTorque = horsePower * gasInput * Time.deltaTime;
    }
    public void ApplySteering()
    {
        float steeringWheelRotation = steeringWheel.transform.localEulerAngles.z;
        steeringWheelRotation = (steeringWheelRotation + 360) % 360;
        
        float normalizedSteeringInput = (steeringWheelRotation > 180) ?
            Mathf.InverseLerp(180, 360, steeringWheelRotation) * 2 - 1 : Mathf.InverseLerp(0, 180, steeringWheelRotation) * 2;
        
        
        float minSteeringInput = -1f;
        float maxSteeringInput = 1f;
        steeringInput = Mathf.Clamp(normalizedSteeringInput, minSteeringInput, maxSteeringInput);


        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);


        float minSteeringAngle = -60;
        float maxSteeringAngle = 60;
       
        if(steeringAngle <= minSteeringAngle)
        {
            steeringAngle = minSteeringAngle;
        }
        if(steeringAngle >= maxSteeringAngle)
        {
            steeringAngle = maxSteeringAngle;
        }
       
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