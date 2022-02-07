using UnityEngine;
using UnityEngine.Events;

public class SOBoolHelper : MonoBehaviour
{
    [SerializeField] private SOBool soBool;
    [SerializeField] private bool currentValue;

    [SerializeField] private bool resetValueOnAwake;
    [SerializeField] private bool defaultValue;

    [SerializeField] private UnityEvent<bool> onValueChanged;
    [SerializeField] private UnityEvent onValueChangedToTrue;
    [SerializeField] private UnityEvent onValueChangedToFalse;
    [SerializeField] private UnityEvent onValueReset;

    
    private void Awake()
    {
        currentValue = soBool.GetValue();
        if (resetValueOnAwake)
        {
            soBool.ResetValue();
        }
    }

    private void OnEnable()
    {
        soBool.onValueChanged += HandleValueChanged;
        soBool.onValueReset += HandleValueReset;
    }

    private void OnDisable()
    {
        soBool.onValueChanged -= HandleValueChanged;
        soBool.onValueReset -= HandleValueReset;
    }

    private void HandleValueChanged(bool value)
    {
        
        onValueChanged?.Invoke(value);
        if (value)
        {
            
            onValueChangedToTrue?.Invoke();
        }
        else
        {
            
            onValueChangedToFalse?.Invoke();
        }
        currentValue = soBool.GetValue();
    }

    private void HandleValueReset()
    {
        
        onValueReset?.Invoke();
        currentValue = soBool.GetValue();
    }

    [ContextMenu("Toggle Bool")]
    public void ToggleBool()
    {
        soBool.ToggleValue();
        currentValue = soBool.GetValue();
    }
    

}
