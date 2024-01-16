using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RaycastHandInGame : MonoBehaviour
{
    public GameObject keyboardPanel;
    public GameObject leaderBoardPanel;
    public TMP_Text inputField;
    public TMP_Text inputfieldLeaderBOard;
    public LayerMask keyBoardLayer;
    public LayerMask nameInputField;
    public LayerMask submit;
    public RaycastHit hit;
    public float rayLenght;
    public bool isPressed;
    private LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
        lineRenderer.startWidth = 0.009f;
        lineRenderer.endWidth = 0.009f;
    }
    private void Update()
    {
        performRaycasts();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + transform.forward * rayLenght);
    }
    public void performRaycasts()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, rayLenght, submit))
        {
            if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                Button button = hit.collider.GetComponent<Button>();
                if(button != null)
                {
                    //button.onClick.Invoke();
                }
            }
            
        }
        
        if (Physics.Raycast(ray, out hit, rayLenght, nameInputField))
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                keyboardPanel.SetActive(true);
                leaderBoardPanel.SetActive(false);
            }
               
        }
       
        if (Physics.Raycast(ray, out hit, rayLenght, keyBoardLayer))
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                
                KeyPress pressedKey = hit.collider.GetComponent<KeyPress>();
                if (pressedKey != null && !isPressed)
                {
                    char characther = pressedKey.characther;
                    if (characther == '1') // backspace
                    {
                        if (inputField.text.Length > 0)
                        {
                            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
                        }
                    }
                    else if (characther == '2')// enter
                    {
                        keyboardPanel.SetActive(false);
                        leaderBoardPanel.SetActive(true);
                        inputfieldLeaderBOard.text = inputField.text;
                    }
                    else
                    {
                        
                        inputField.text += pressedKey.characther;
                    }
                    isPressed = true;
                }
            }
            else
            {
                isPressed = false;
            }
           
            
        }
        
        
    }
   
}
