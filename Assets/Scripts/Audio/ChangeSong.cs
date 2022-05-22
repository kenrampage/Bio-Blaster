using UnityEngine;
using System.Collections;

public class ChangeSong : MonoBehaviour
{

    public SOFMODMusicRemote battleMusicRemote;
    public SOFMODMusicRemote travelMusicRemote;


    [ContextMenu("Start Battle Music")]
    public void StartBattleMusic()
    {
        StopAllCoroutines();
        // travelMusicRemote.StopPlaybackWithFadeout();
        StartCoroutine(StopMusicAfterDelay(1, travelMusicRemote));
        StartCoroutine(StartMusicAfterDelay(3, battleMusicRemote));

    }

    [ContextMenu("Start Travel Music")]
    public void StartTravelMusic()
    {
        StopAllCoroutines();
        battleMusicRemote.SetSection(1);
        // battleMusicRemote.StopPlaybackWithFadeout();
        StartCoroutine(StopMusicAfterDelay(1, battleMusicRemote));
        StartCoroutine(StartMusicAfterDelay(3, travelMusicRemote));

    }

    public IEnumerator StartMusicAfterDelay(float delayTime, SOFMODMusicRemote musicRemote)
    {
        yield return new WaitForSecondsRealtime(delayTime);
        musicRemote.StopPlayback();
        musicRemote.StartPlayback();
    }

    public IEnumerator StopMusicAfterDelay(float delayTime, SOFMODMusicRemote musicRemote)
    {
        yield return new WaitForSecondsRealtime(delayTime);
        musicRemote.StopPlaybackWithFadeout();

    }

    public IEnumerator SetSectionAfterDelay(float delayTime, int section, SOFMODMusicRemote musicRemote)
    {
        yield return new WaitForSecondsRealtime(delayTime);
        musicRemote.SetSection(section);
    }
}
