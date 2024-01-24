using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       ResetScene();
    }
   
    public void ResetScene()
    {
        if(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        
    }
}
