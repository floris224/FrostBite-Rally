using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public PutVrOn putVrOn;
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject videoSettingMenu;
    public GameObject creditsMenu;
    public GameObject putOnVR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        putVrOn.startIsPressed = true;
        mainMenu.SetActive(false);
        putOnVR.SetActive(true);
    }
    public void GoToSettings()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void GoToCreditsMenu()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void GoToMainMenu() 
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void GoToVideoSettings()
    {
        settingMenu.SetActive(false);
        videoSettingMenu.SetActive(true);
    }
    public void GoToBackSettings()
    {
        videoSettingMenu.SetActive(false);
        settingMenu.SetActive(true);
    }
    public void Quit() 
    { 
        Application.Quit();
    }
}
