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
    //left hand
    public GameObject leftHand;
    public Transform leftHandOriginalParent;
    public bool leftHandOnWheel;
    public Transform steeringWheel;

    public bool leftHandOnWheelReadyToLetGo;
    public bool rightHandOnWheelReadyToLetGo;
   // public GameObject steeringWheel;
    public Transform[] snapPositions;

    public GameObject car;
    public Rigidbody carRB;

    public float currentSteeringWheelRotation;
    public float numberOfHandsOnWheel = 0;

   

    public GameObject fakeHandsR;
    public GameObject fakeHandsL;

    public GameObject realHandsR;
    public GameObject realHandsL;
    private float turnDampening = 250;
    


    public GameObject player;
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

        if (leftHandOnWheel)
        {
            player.transform.parent = car.transform;
            Debug.LogError("Test");
            leftHandOnWheelReadyToLetGo = true;
            fakeHandsL.GetComponent<SkinnedMeshRenderer>().enabled = true;
            realHandsL.GetComponent<SkinnedMeshRenderer>().enabled = false;
            
            numberOfHandsOnWheel++;

        }
        if (rightHandOnWheel)
        {

            player.transform.parent = car.transform;
            fakeHandsR.GetComponent<SkinnedMeshRenderer>().enabled = true;
            realHandsR.GetComponent<SkinnedMeshRenderer>().enabled = false;
            rightHandOnWheelReadyToLetGo = true;
            numberOfHandsOnWheel++;
        }

        ReleaseHand();
        float rotationZ = transform.rotation.z;
        float maxRotationZ = 60;
        float minRotationZ = -60;

        if(rotationZ >= maxRotationZ)
        {
            rotationZ = maxRotationZ;
        }
        if(rotationZ <= minRotationZ)
        {
            rotationZ = minRotationZ;
        }
    }
    private void LateUpdate()
    {
       
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("PlayerHand"))
        {
            
            if (rightHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
               
                PlaceHandOnWheel(ref rightHand, ref rightHandOriginalParent, ref rightHandOnWheel);
                rightHandOnWheel = true;
            }

            if(leftHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
               
                PlaceHandOnWheel(ref leftHand,ref leftHandOriginalParent, ref leftHandOnWheel);
                leftHandOnWheel = true;
            }
        }
    }

    private void PlaceHandOnWheel(ref GameObject hand, ref Transform originalParent,ref bool handOnWheel)
    {
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
      
        
        
        originalParent = hand.transform;
    }
   
  
    private void ReleaseHand()
    {
        if(rightHandOnWheelReadyToLetGo == true && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            rightHand.transform.parent = rightHandOriginalParent;
            rightHand.transform.position = rightHandOriginalParent.transform.position;
            fakeHandsR.GetComponent<SkinnedMeshRenderer>().enabled = false;
            realHandsR.GetComponent<SkinnedMeshRenderer>().enabled = true;
            rightHandOnWheelReadyToLetGo = false;
            rightHandOnWheel = false;
            numberOfHandsOnWheel--;
        }
        else if (leftHandOnWheelReadyToLetGo == true && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            leftHand.transform.parent = leftHandOriginalParent;
            leftHand.transform.position = leftHandOriginalParent.transform.position;

            fakeHandsL.GetComponent<SkinnedMeshRenderer>().enabled = false;
            realHandsL.GetComponent<SkinnedMeshRenderer>().enabled = true;
            leftHandOnWheelReadyToLetGo = false;
            leftHandOnWheel = false;
            numberOfHandsOnWheel--;
           
        }
      
    }
}
