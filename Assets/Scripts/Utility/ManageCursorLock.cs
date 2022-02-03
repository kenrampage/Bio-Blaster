using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCursorLock : MonoBehaviour
{
    public bool startUnlocked;

    private void Start()
    {
        if (startUnlocked)
        {
            UnlockCursor();
        }
        else
        {
            LockCursor();
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
