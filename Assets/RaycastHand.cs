using EasyRoads3Dv3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class RaycastHand : MonoBehaviour
{
    public float rayLenght = 100f;
   
    RaycastHit hit;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if(lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
        lineRenderer.startWidth = 0.009f;
        lineRenderer.endWidth = 0.009f;
        
    }

    // Update is called once per frame
    void Update()
    {
      
        PeformRaycast();
        //CheckUIInteraction();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1,transform.position + transform.forward * rayLenght);
        
    }
    public void PeformRaycast()
    {
        int layerMask = 1 << LayerMask.NameToLayer("UI");
        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, rayLenght,layerMask))
        {
            if (hit.collider.tag == "Settings")
            {
                if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
                {
                    
                    Button button = hit.collider.GetComponent<Button>();
                    Dropdown dropdown = hit.collider.GetComponent<Dropdown>();
                    Toggle toggle = hit.collider.GetComponent<Toggle>();
                   
                    if (button != null)
                    {
                        button.onClick.Invoke();
                    }
                    if(dropdown != null)
                    {
                        dropdown.Show();
                    }
                    if(toggle != null)
                    {
                        toggle.isOn = !toggle.isOn;
                    }
                    
                }

            }
        }

    }
   /* void CheckUIInteraction()
    {
       
    }
   */
    
}
