using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Drive : MonoBehaviour
{
    public Rigidbody sphereRb;
    
    public InputActionAsset asset;
    public InputAction driveInputfw;
    public InputAction rotationInput;
    public float moveInput;
    public float turnInput;
    public bool isCarGrounded;
    public float groundDrag;
    public float airDrag;
    public float fwSpeed;
    public float revSpeed;
    public float turnSpeed;
    public LayerMask groundLayer;
    private void Start()
    {
        sphereRb.transform.parent = null;
    }
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
    private void Update()
    {
        moveInput = driveInputfw.ReadValue<float>();
        moveInput *= moveInput > 0 ? fwSpeed : revSpeed;
        
        turnInput = rotationInput.ReadValue<float>();
        
        Debug.Log(turnInput);
       

        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);

        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        if (isCarGrounded)
        {
            sphereRb.drag = groundDrag;
        }
        else
        {
            sphereRb.drag = airDrag;
        }
        transform.position = sphereRb.transform.position;
    }
    public void FixedUpdate()
    {
        float newRotation = turnInput * turnSpeed * Time.deltaTime;
        if (isCarGrounded)
        {
            Vector3 fowardForce = transform.forward * moveInput;
            sphereRb.AddForce(fowardForce, ForceMode.Impulse);
            if (moveInput != 0)
            {
                transform.Rotate(0, newRotation, 0, Space.World);
            }
        }
        else
        {
            sphereRb.AddForce(transform.up * -18.8f);
        }
       
        
    }


}
