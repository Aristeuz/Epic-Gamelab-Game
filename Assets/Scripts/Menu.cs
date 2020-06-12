using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject displayCanvas;
    public GameObject audioCanvas;
    public GameObject controlsCanvas;

    //currently both resume and new game, will go to the demo scene, as there is no save game option yet
    public void StartGame()
    {
        SceneManager.LoadScene("Demo Scene");
    }

    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene("Settings Menu");
    }

    public void LoadDisplaySettings()
    {
        //SceneManager.LoadScene("Settings Display");
        displayCanvas.SetActive(true);
        audioCanvas.SetActive(false);
        controlsCanvas.SetActive(false);
        Debug.Log("Display switch");
    }

    public void LoadAudioSettings()
    {
        //SceneManager.LoadScene("Settings Audio");
        displayCanvas.SetActive(false);
        audioCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
        Debug.Log("audio switch");
    }

    public void LoadControlsSettings()
    {
        //SceneManager.LoadScene("Settings Controls");
        displayCanvas.SetActive(false);
        audioCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
        Debug.Log("controlls switch");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
