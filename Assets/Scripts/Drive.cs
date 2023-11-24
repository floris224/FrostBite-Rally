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
        // inputs
        moveInput = driveInputfw.ReadValue<float>();
        moveInput *= moveInput > 0 ? fwSpeed : revSpeed;
        
        turnInput = rotationInput.ReadValue<float>();
        
        Debug.Log(turnInput);
       
        //raycast that searches for the ground
        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, groundLayer);

        //puts car right way
        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        
        if (isCarGrounded)
        {
            // drag = grounddrag
            sphereRb.drag = groundDrag;
        }
        else
        {
            // drag = air drag
            sphereRb.drag = airDrag;
        }
        // car follows Sphere
        transform.position = sphereRb.transform.position;
    }
    public void FixedUpdate()
    {
        float newRotation = turnInput * turnSpeed * Time.deltaTime;
        if (isCarGrounded)
        {
            // car grounded move
            Vector3 fowardForce = transform.forward * moveInput;
            sphereRb.AddForce(fowardForce, ForceMode.Impulse);
            if (moveInput != 0)
            {
                transform.Rotate(0, newRotation, 0, Space.World);
            }
        }
        else
        {
            // gravity
            sphereRb.AddForce(transform.up * -18.8f);
        }
       
        
    }


}
