using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;


    [Header("Audio")]
    [Range(0,1)]
    public float musicVolume = 1;

    [Range(0, 1)]
    public float sfxVolume = 1;

    [Range(0, 1)]
    public float voiceVolume = 1;

    [Range(0, 1)]
    public float enviromentVolume = 1;

    [Header("Display")]
    public float _screenResolution = 0f;

    public bool _fullScreen;

    public bool _HUD;

    private void Awake()
    {
        //Make sure there will never be another instance except for the first one. 
        if (instance != null)
        {
            Debug.Log("Second instance of SettingsManager wanted to be created, but is now destroyed.");
            Destroy(this);
        }
        else
        {
            Debug.Log("I exist");
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
            
    }
}
