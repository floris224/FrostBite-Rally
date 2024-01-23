using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiGOHome : MonoBehaviour
{
    private void Update()
    {
       
    }

    public void ButtonGoHome()
    {
        SceneManager.LoadScene(0);
        
    }
}
