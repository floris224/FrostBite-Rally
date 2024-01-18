using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiGOHome : MonoBehaviour
{

    public void ButtonGoHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("FUCK YOU UNITY");
    }
}
