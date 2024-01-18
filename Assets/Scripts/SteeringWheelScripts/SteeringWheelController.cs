using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SteeringWheelController : MonoBehaviour
{
   // public CarMovement carMovement;
    // right Hand
    public GameObject rightHand;
    public Transform rightHandOriginalParent;
    public bool rightHandOnWheel;
   
    public GameObject leftHand;
    public Transform leftHandOriginalParent;
    public bool leftHandOnWheel;
    public Transform steeringWheel;

    public bool leftHandOnWheelReadyToLetGo;
    public bool rightHandOnWheelReadyToLetGo;
   
    public Transform[] snapPositions;

    public GameObject car;
    public Rigidbody carRB;

    public float currentSteeringWheelRotation;
    public float numberOfHandsOnWheel = 0;

   

    public GameObject fakeHandsR;
    public GameObject fakeHandsL;

    public GameObject realHandsR;
    public GameObject realHandsL;
 

    public HandRot handrotationFix;

    public GameObject player;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        carRB = car.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        
        
    }

    private void Update()
    {
        //Changes hands when interacting with the steeringwheel
        if (leftHandOnWheel)
        {
            player.transform.parent = car.transform;
        
            leftHandOnWheelReadyToLetGo = true;
            fakeHandsL.GetComponent<SkinnedMeshRenderer>().enabled = true;
            realHandsL.GetComponent<SkinnedMeshRenderer>().enabled = false;
            
            

        }
        if (rightHandOnWheel)
        {

            player.transform.parent = car.transform;
            fakeHandsR.GetComponent<SkinnedMeshRenderer>().enabled = true;
            realHandsR.GetComponent<SkinnedMeshRenderer>().enabled = false;
            rightHandOnWheelReadyToLetGo = true;
            
        }
        /*if(leftHandOnWheel && rightHandOnWheel || leftHandOnWheel || rightHandOnWheel)
        {
            timer.enabled = true;
        }
        */
        ReleaseHand();
       
    }
  
    private void OnTriggerStay(Collider other)
    {
        //Checks if hands are in the collider of the steeringwheel
        
        if (other.CompareTag("PlayerHandR"))
        {
           
            if (rightHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                Debug.Log("Hands are in");
                PlaceHandOnWheel(ref rightHand, ref rightHandOriginalParent, ref rightHandOnWheel);
                rightHandOnWheel = true;
            }

           
        }
        if (other.CompareTag("PlayerHandL"))
        {
            if (leftHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                handrotationFix.enabled = true;
                PlaceHandOnWheel(ref leftHand, ref leftHandOriginalParent, ref leftHandOnWheel);
                leftHandOnWheel = true;
            }
        }
    }

    private void PlaceHandOnWheel(ref GameObject hand, ref Transform originalParent,ref bool handOnWheel)
    {
        // for later finds best snap point in steeringwheel and then searches for best grip pose

        /*
        var shortestDistance = Vector3.Distance(snapPositions[0].position, hand.transform.position);
        var bestSnap = snapPositions[0];
        
        foreach (var snappPosition in snapPositions)
        {
            if(snappPosition.childCount == 0)
            {
                
                
                var distance = Vector3.Distance(snappPosition.position, hand.transform.position);
                if(distance < shortestDistance)
                {
                    shortestDistance = distance;
                    bestSnap = snappPosition;
                }
            }
        }
       
        hand.transform.parent = bestSnap.transform;
        hand.transform.position = bestSnap.transform.position;
        */
        //steeringWheel.rotation = Quaternion.identity;
      
        
        // sets the original parent transform to hands transform
        originalParent = hand.transform;
    }
   
  
    private void ReleaseHand()
    {

        // checks if hands are ready to let go if so press A to let Go
        // same goes for left hand 
        if(rightHandOnWheelReadyToLetGo == true && OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            rightHand.transform.parent = rightHandOriginalParent;
            rightHand.transform.position = rightHandOriginalParent.transform.position;
            fakeHandsR.GetComponent<SkinnedMeshRenderer>().enabled = false;
            realHandsR.GetComponent<SkinnedMeshRenderer>().enabled = true;
            rightHandOnWheelReadyToLetGo = false;
            rightHandOnWheel = false;
            
        }
        else if (leftHandOnWheelReadyToLetGo == true && OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            handrotationFix.enabled = false;
            leftHand.transform.parent = leftHandOriginalParent;
            leftHand.transform.position = leftHandOriginalParent.transform.position;

            fakeHandsL.GetComponent<SkinnedMeshRenderer>().enabled = false;
            realHandsL.GetComponent<SkinnedMeshRenderer>().enabled = true;
            leftHandOnWheelReadyToLetGo = false;
            leftHandOnWheel = false;
            
           
        }
      
    }
}
