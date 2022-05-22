using UnityEngine;
using FMODUnity;
using FMOD;

public class FMODPlaySimple : MonoBehaviour
{
    public FMODUnity.EventReference fmodEvent;
    // [SerializeField] [EventRef] private string fmodEvent;
    [SerializeField] private bool startOnEnable;
    [SerializeField] private FMOD.Studio.PLAYBACK_STATE playbackState;

    private bool playAttached;

    private FMOD.Studio.EventInstance eventInstance;

    private void Update()
    {
        if (playAttached)
        {
            eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        }
    }

    public void InitializeEvent()
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);

        bool is3D;
        RuntimeManager.GetEventDescription(fmodEvent).is3D(out is3D);

        playAttached = is3D = true ? true : false;
        GetPlaybackState();
    }

    private void OnEnable()
    {
        InitializeEvent();
        if (startOnEnable)
        {
            StartEvent();
        }
    }

    private void OnDisable()
    {
        ReleaseEvent();
    }

    private void OnDestroy()
    {
        StopEventWithFadeout();
        ReleaseEvent();
    }

    [ContextMenu("Start Event")]
    public void StartEvent()
    {
        print("Event Started at: " + transform.position);
        GetPlaybackState();
        if (playbackState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            eventInstance.start();
            GetPlaybackState();
        }

    }

    public void PauseEvent()
    {
        eventInstance.setPaused(true);
        GetPlaybackState();
    }

    public void UnpauseEvent()
    {
        eventInstance.setPaused(false);
        GetPlaybackState();
    }

    public void StopEventNoFadeout()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        GetPlaybackState();
    }

    public void StopEventWithFadeout()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        GetPlaybackState();
    }


    public void ReleaseEvent()
    {
        eventInstance.release();
        playAttached = false;
    }

    public void GetPlaybackState()
    {
        eventInstance.getPlaybackState(out playbackState);
    }
}
