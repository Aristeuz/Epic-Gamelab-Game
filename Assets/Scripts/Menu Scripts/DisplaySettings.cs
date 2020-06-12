using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplaySettings : MonoBehaviour
{
    public GameObject resolution;
    TextMeshProUGUI resolutionText;
    public float resNumber = 0f;

    public GameObject windowMode;
    TextMeshProUGUI windowModeText;
    public bool fullScreen = true;

    //public GameObject HUD;
    //public bool enableHUD;

    // Start is called before the first frame update
    void Start()
    {
        resolutionText = resolution.GetComponent<TextMeshProUGUI>();
        windowModeText = windowMode.GetComponent<TextMeshProUGUI>();
        LoadSettings();
    }

    //Changes the fullscreen to windowed and vise versa
    public void changeFullscreen()
    {
        fullScreen = !fullScreen;

        SetScreenRes();
    }

    public void brightnessLevel()
    {

    }

    public void enableHUD()
    {

        //SettingsManager.instance._HUD = HUD;
    }

    //make the number on the list go down
    public void ScreenResDown()
    {
        if (resNumber < 3)
        {
            resNumber += 1;
            SetScreenRes();
        }
    }

    //Make the number on the list go up
    public void ScreenResUP()
    {
        if (resNumber > 0)
        {
            resNumber -= 1;
            SetScreenRes();
        }
    }

    //Changes the resolution
    void SetScreenRes()
    {
        //change name here since the changeFullscreen() goes to this function anyway.
        if (fullScreen == true)
            windowModeText.text = "Fullscreen";
        if (fullScreen == false)
            windowModeText.text = "Windowed";

        switch (resNumber)
        {
            case 0f:
                Screen.SetResolution(1920, 1080, fullScreen);
                resolutionText.text = "1920 x 1080";
                break;
            case 1f:
                Screen.SetResolution(1600, 900, fullScreen);
                resolutionText.text = "1600 x 900";
                break;
            case 2f:
                Screen.SetResolution(1366, 768, fullScreen);
                resolutionText.text = "1366 x 768";
                break;
            case 3f:
                Screen.SetResolution(1280, 800, fullScreen);
                resolutionText.text = "1280 x 800";
                break;
        }
        SettingsManager.instance._screenResolution = resNumber;
        SettingsManager.instance._fullScreen = fullScreen;
    }

    void LoadSettings()
    {
        //Debug.Log(SettingsManager.instance);
        //Load the value from settingsmanager back into this local mananager.
        fullScreen = SettingsManager.instance._fullScreen;
        resNumber = SettingsManager.instance._screenResolution;
        //HUD = ettingsManager.instance._HUD;

        //Set the value of the slider to be the current value.
        SetScreenRes();

    }
}
