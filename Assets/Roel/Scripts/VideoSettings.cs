using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionsDropDown;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {

            }
        }
        resolutionsDropDown.AddOptions(options);
        resolutionsDropDown.value = currentindex;
        resolutionsDropDown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ToggleFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetQuality(int qualiIndex)
    {
        QualitySettings.SetQualityLevel(qualiIndex);
    }
}
