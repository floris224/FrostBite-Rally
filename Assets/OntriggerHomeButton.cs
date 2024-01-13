using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OntriggerHomeButton : MonoBehaviour
{
    public Button homeButton;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerHandL" && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch) || other.tag == "PlayerHandR" && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            homeButton.onClick.Invoke();
        }
    }
}
