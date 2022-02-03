using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEventAfterDelay : MonoBehaviour
{
    public float delaySeconds;
    public UnityEvent eventToInvoke;

    public void StartDelayTimer()
    {
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSecondsRealtime(delaySeconds);

        eventToInvoke?.Invoke();

    }

}
