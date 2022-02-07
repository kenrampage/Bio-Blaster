using UnityEngine;
using System;


[CreateAssetMenu(fileName = "Bool_", menuName = "Ken's Helpers/SOBool")]
public class SOBool : ScriptableObject
{
    [SerializeField] private bool defaultValue;
    [SerializeField] public bool value;


    public Action<bool> onValueChanged;

    public Action onValueReset;


    public bool GetValue()
    {
        return value;
    }

    public void SetValue(bool b)
    {
        if (b != value)
        {
            value = b;
            onValueChanged?.Invoke(value);
        }

    }

    public void ToggleValue()
    {
        value = !value;
        onValueChanged?.Invoke(value);
    }


    public void ResetValue()
    {
        value = defaultValue;
        onValueReset?.Invoke();
    }

    public void SetDefaultValue(bool b)
    {
        defaultValue = b;
    }
}
