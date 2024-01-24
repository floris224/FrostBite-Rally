using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public PutVrOn putVrOn;
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject videoSettingMenu;
    public GameObject creditsMenu;
    public GameObject putOnVR;
    public GameObject mapSelect;
    public List<GameObject> maps;
    public List<GameObject> cars;
    public List<GameObject> mapScenes;
    public bool startPressed;
    public bool putVROn = true;
    public int listIndex;
    // Start is called before the first frame update
    void Start()
    {
        listIndex = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startPressed && !putVROn == true)
        {
            MapSelect();
        }
       
    }
    public void StartGame()
    {
        startPressed = true;
        mapSelect.SetActive(true);
        
        mainMenu.SetActive(false);
        
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
        startPressed = false;
        creditsMenu.SetActive(false);
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
    public void NextMap()
    {

        maps[listIndex].SetActive(false);

        cars[listIndex].SetActive(false);
        listIndex += 1;
        maps[listIndex].SetActive(true);
        
    }
    public void LastMap()
    {
        maps[listIndex].SetActive(false);
        cars[listIndex].SetActive(false);
        listIndex -= 1;
        maps[listIndex].SetActive(true);

    }
    public void MapSelect()
    {
        maps[listIndex].SetActive(true);
        cars[listIndex].SetActive(true);
       

    }
    public void PlayButton()
    {
        mapScenes[listIndex].SetActive(false);
        putVROn = true;
        putVrOn.startIsPressed = true;
        putOnVR.SetActive(true);
    }
}
