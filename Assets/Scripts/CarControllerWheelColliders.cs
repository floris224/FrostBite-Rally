using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
public class CarControllerWheelColliders : MonoBehaviour
{
    public InputActionAsset asset;
    public InputAction driveInputfw;
    public InputAction rotationInput;
    public float moveInput;
    public float turnInput;
    public WheelCollider[] wheelColliders;
    public Transform[] wheels;
    float torque = 100;
    float angle = 45;


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
   

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = driveInputfw.ReadValue<float>();

        turnInput = rotationInput.ReadValue<float>();
        for (int i = 0; i < wheelColliders.Length; i++)
        {
           wheelColliders[i].brakeTorque = 0;

            wheelColliders[i].motorTorque = moveInput * torque ;
            if (i == 0 || i == 2)
            {
                wheelColliders[i].steerAngle = turnInput * angle;
            }
            
            var pos = transform.position;
            var rot = transform.rotation;
            wheelColliders[i].GetWorldPose(out pos, out rot);
            wheels[i].position = pos;
            wheels[i].rotation = rot;
            
            
        }
        
    }
}
