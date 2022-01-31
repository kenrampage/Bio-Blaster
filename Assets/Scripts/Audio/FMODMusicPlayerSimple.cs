using UnityEngine;
using FMODUnity;
using FMOD;

public class FMODMusicPlayerSimple : MonoBehaviour
{
    public FMODUnity.EventReference fmodEvent;
    [SerializeField] private FMOD.Studio.EventInstance eventInstance;

    public FMOD.Studio.PLAYBACK_STATE playbackState;
    public bool isPaused;
    public int targetSection;

    public bool playOnStart;

    private void Start()
    {
        if(playOnStart)
        {
            StartPlayback();
        }
    }

    // public bool playOnEnable;

    // private void OnEnable()
    // {
    //     if (playOnEnable)
    //     {
    //         StartPlayback();
    //     }
    // }

    // private void OnDisable()
    // {
    //     StopPlaybackFadeout();
    // }


    private void SetEventInstance()
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    public void InitializePlayer()
    {
        eventInstance.release();

        SetEventInstance();
        GetPlaybackState();
    }

    [ContextMenu("Get Playback State")]
    private void GetPlaybackState()
    {
        eventInstance.getPlaybackState(out playbackState);
        eventInstance.getPaused(out isPaused);
    }

    public void TogglePause()
    {
        GetPlaybackState();

        if (playbackState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            StartPlayback();
        }
        else if (playbackState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {


            if (isPaused)
            {
                PausePlayback();
            }
            else
            {
                UnpausePlayback();
            }
        }
    }

    [ContextMenu("Pause Music")]
    public void PausePlayback()
    {
        eventInstance.setPaused(true);
        GetPlaybackState();
    }

    public void UnpausePlayback()
    {
        eventInstance.setPaused(false);
        GetPlaybackState();
    }

    [ContextMenu("Play Music")]
    public void StartPlayback()
    {
        InitializePlayer();
        eventInstance.start();
        GetPlaybackState();
    }


    [ContextMenu("Stop")]
    public void StopPlayback()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        targetSection = 0;
        SetSectionManual();
        GetPlaybackState();
    }

    [ContextMenu("Stop with Fadeout")]
    public void StopPlaybackFadeout()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        targetSection = 0;
        SetSectionManual();
        GetPlaybackState();
    }

    public void SetSection(int i)
    {
        eventInstance.setParameterByName("Section", i);
    }

    [ContextMenu("Set Section")]
    public void SetSectionManual()
    {
        eventInstance.setParameterByName("Section", targetSection);
    }


    public void SetHighpassOn()
    {
        eventInstance.setParameterByName("HighPass", 1);
    }

    public void SetHighpassOff()
    {
        eventInstance.setParameterByName("HighPass", 0);
    }

    public void SetParameterByName(string parameterName, float value)
    {
        eventInstance.setParameterByName(parameterName, value);
    }
}
