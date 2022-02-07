using UnityEngine;
using FMODUnity;
using System;

[CreateAssetMenu(fileName = "FMODMusicRemote_", menuName = "Ken's Helpers/SOFMODMusicRemote")]
public class SOFMODMusicRemote : ScriptableObject
{
    public FMODUnity.EventReference fmodEvent;
    // [EventRef] public string[] fmodEvents;
    // public int eventIndex;
    // public bool shuffle;

    public event Action onPauseToggleTriggered;
    public event Action onPlaybackStartTriggered;
    public event Action onPlaybackStopTriggered;
    public event Action onPlaybackStopWithFadeoutTriggered;
    public event Action<int> onSetSectionTriggered;
    public event Action onSetHighPassOnTriggered;
    public event Action onSetHighPassOffTriggered;

    public void TogglePause()
    {
        onPauseToggleTriggered?.Invoke();
    }

    public void StartPlayback()
    {
        onPlaybackStartTriggered?.Invoke();
    }

    public void StopPlayback()
    {
        onPlaybackStopTriggered?.Invoke();
    }

    public void StopPlaybackWithFadeout()
    {
        onPlaybackStopWithFadeoutTriggered?.Invoke();
    }

    public void SetSection(int value)
    {
        onSetSectionTriggered?.Invoke(value);
    }

    public void SetHighpassOn()
    {
        onSetHighPassOnTriggered?.Invoke();
    }

    public void SetHighPassOff()
    {
        onSetHighPassOffTriggered?.Invoke();
    }

}
