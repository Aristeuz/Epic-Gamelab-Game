using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    FMOD.Studio.EventInstance SFXVolumeTestEvent;

    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;
    FMOD.Studio.Bus Voice;
    FMOD.Studio.Bus Enviroment;
    float MusicVolume = 1f;
    float SFXVolume = 1f;
    float VoiceVolume = 1f;
    float EnviromentVolume = 1f;

    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider voiceVolumeSlider;
    public Slider enviromentVolumeSlider;

    // Start is called before the first frame update
    void Awake()
    {
        //Link classes to the busses
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        Voice = FMODUnity.RuntimeManager.GetBus("bus:/Master/Voice");
        Enviroment = FMODUnity.RuntimeManager.GetBus("bus:/Master/Enviroment");
        SFXVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFXtest");
    }

    private void Start()
    {
        //Load all settings.
        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        //updates values every step
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
        Voice.setVolume(VoiceVolume);
        Enviroment.setVolume(EnviromentVolume);
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
        SettingsManager.instance.musicVolume = MusicVolume;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;
        SettingsManager.instance.sfxVolume = SFXVolume;

        //Play the SFXtest sound whenever you change the sfx. So the player has a reference. And also it doesn't spam
        FMOD.Studio.PLAYBACK_STATE PlaybackState;
        SFXVolumeTestEvent.getPlaybackState(out PlaybackState);
        if (PlaybackState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTestEvent.start();
        }
    }

    public void VoiceVolumeLevel(float newVoiceVolume)
    {
        VoiceVolume = newVoiceVolume;
        SettingsManager.instance.voiceVolume = VoiceVolume;
    }

    public void EnviromentVolumeLevel(float newEnviromentVolume)
    {
        EnviromentVolume = newEnviromentVolume;
        SettingsManager.instance.enviromentVolume = EnviromentVolume;
    }

    void LoadSettings()
    {
        Debug.Log(SettingsManager.instance);
        //Load the value from settingsmanager back into this local mananager.
        MusicVolume = SettingsManager.instance.musicVolume;
        SFXVolume = SettingsManager.instance.sfxVolume;
        VoiceVolume = SettingsManager.instance.voiceVolume;
        EnviromentVolume = SettingsManager.instance.enviromentVolume;

        //Set the value of the slider to be the current value.
        musicVolumeSlider.value = MusicVolume;
        sfxVolumeSlider.value = SFXVolume;
        voiceVolumeSlider.value = VoiceVolume;
        enviromentVolumeSlider.value = EnviromentVolume;
    }
}
