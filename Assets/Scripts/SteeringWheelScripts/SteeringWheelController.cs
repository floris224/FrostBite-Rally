using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelController : MonoBehaviour
{
    // right Hand
    public GameObject rightHand;
    private Transform rightHandOriginalParent;
    public bool rightHandOnWheel;
    //left hand
    public GameObject leftHand;
    private Transform leftHandOriginalParent;
    public bool leftHandOnWheel;

    public Transform[] snapPositions;

    public GameObject car;
    public Rigidbody carRB;

    public float currentSteeringWheelRotation;
    public float numberOfHandsOnWheel = 0;

    public GameObject testRight;
    public GameObject testLeft;

    private float turnDampening = 250;
    public Transform directionalObject;
    // Start is called before the first frame update
    void Start()
    {
        carRB = car.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("PlayerHand"))
        {
            Debug.LogError("In");
            if (rightHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                testRight.SetActive(false);
                PlaceHandOnWheel(ref rightHand, ref rightHandOriginalParent, ref rightHandOnWheel);
            }

            if(leftHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                testLeft.SetActive(false);
                PlaceHandOnWheel(ref leftHand,ref leftHandOriginalParent, ref leftHandOnWheel);
            }
        }
    }

    private void PlaceHandOnWheel(ref GameObject hand, ref Transform originalParent,ref bool handOnWheel)
    {
        var shortestDistance = Vector3.Distance(snapPositions[0].position, hand.transform.position);
        var bestSnap = snapPositions[0];

        foreach(var snappPosition in snapPositions)
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
        originalParent = hand.transform;
        hand.transform.parent = bestSnap.transform;
        hand.transform.position = bestSnap.transform.position;

        handOnWheel = true;
        numberOfHandsOnWheel++;
    }

    private void ConvertHandRotationToSteeringWheel()
    {

    }
    
}
