using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HandleToggle : MonoBehaviour
{

    private Toggle toggle;

    [SerializeField] private UnityEvent onToggleOn;
    [SerializeField] private UnityEvent onToggleOff;

    private void OnEnable()
    {
        toggle = GetComponent<Toggle>();
        HandleToggleValueChange();
    }

    public void HandleToggleValueChange()
    {
        if (toggle.isOn)
        {
            onToggleOn?.Invoke();
        }
        else
        {
            onToggleOff?.Invoke();
        }
    }
}
