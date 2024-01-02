using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VROnHead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VR"))
        {
            Debug.Log("VR IN");
            SceneManager.LoadScene(1);
        }
    }
}
