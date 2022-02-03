using UnityEngine;
using UnityEngine.Events;

public class OnEnableToggled : MonoBehaviour
{
    [SerializeField] private UnityEvent onEnabled;
    [SerializeField] private UnityEvent onDisabled;

    private void OnEnable()
    {
        onEnabled?.Invoke();
    }

    private void OnDisable()
    {
        onDisabled?.Invoke();
    }

}
