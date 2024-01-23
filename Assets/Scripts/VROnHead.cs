using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VROnHead : MonoBehaviour
{
    public ButtonManager buttonManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VR"))
        {
            Debug.Log("VR IN");
            SceneManager.LoadScene(buttonManager.listIndex);
        }
        if (other.CompareTag("Space"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
