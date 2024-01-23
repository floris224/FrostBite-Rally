using AshVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penalty : MonoBehaviour
{
    public Transform penaltyPoint;
    public int penaltyPower;
    public RaycastHit hit;
    public LayerMask road;
    public CarMovement carscriptMovement;
    public float oldHorsePower;
    public bool penaltyApplied;

    public void Start()
    {
        oldHorsePower = carscriptMovement.horsePower;
    }
    public void Update()
    {
        if(!penaltyApplied && !Physics.Raycast(transform.position, -transform.up, out hit, 50,road))
        {
         
            
            carscriptMovement.horsePower /=penaltyPower;
            penaltyApplied = true;
        }
        else if(Physics.Raycast(transform.position, -transform.up, out hit, 50, road))
        {
            penaltyApplied = false;
            carscriptMovement.horsePower = oldHorsePower;
        }
    }
}
