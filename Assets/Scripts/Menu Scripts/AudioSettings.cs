using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        //updates values every step
        Music.setVolume (MusicVolume);
        SFX.setVolume (SFXVolume);
        Voice.setVolume (VoiceVolume);
        Enviroment.setVolume(EnviromentVolume);
    }

    public void MusicVolumeLevel (float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

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
    }

    public void EnviromentVolumeLevel(float newEnviromentVolume)
    {
        EnviromentVolume = newEnviromentVolume;
    }

}
