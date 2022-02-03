using UnityEngine;
using UnityEngine.Events;

public class HandlePause : MonoBehaviour
{
    public GameObject uiCanvas;
    public bool isPaused;
    public FMODPlayOneShot pauseSound;
    public FMODPlayOneShot unpauseSound;

    [SerializeField] private UnityEvent onPause;
    [SerializeField] private UnityEvent onUnpause;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        EnableTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else if (isPaused)
            {
                UnpauseGame();

            }

        }
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void EnableTime()
    {
        SetTimeScale(1f);
    }

    public void DisableTime()
    {
        SetTimeScale(0);
    }


    public void PauseGame()
    {
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DisableTime();
        uiCanvas.SetActive(true);
        pauseSound.PlaySoundEvent();
        onPause?.Invoke();
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        EnableTime();
        uiCanvas.SetActive(false);
        unpauseSound.PlaySoundEvent();
        onUnpause?.Invoke();
    }
}
