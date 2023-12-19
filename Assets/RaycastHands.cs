using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RaycastHands : MonoBehaviour
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.right, out hit, 50))
        {
            Debug.LogError("Raycast hit" + hit.collider.name);
        }
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 8;
        Gizmos.DrawLine(transform.position, direction);
    }
}
