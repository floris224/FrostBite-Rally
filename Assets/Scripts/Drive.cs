using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Drive : MonoBehaviour
{
    public PlayerController controller;
    public Rigidbody body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        PlayerController controller = new PlayerController();
        controller.Car.Drive.performed += ctx => OnDrive(ctx.ReadValue<Vector2>());

    }
    
    public void OnDrive(Vector2 direction)
    {
        Debug.Log(direction);
        body.AddForce(direction * speed*Time.deltaTime);
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
   /* private void OnEnable()
    {
        controller.Enable();
    }
    private void OnDisable()
    {
        controller.Disable();
    }
   */
}
