
using UnityEngine;
using UnityEngine.Events;

public class TestGameOver : MonoBehaviour
{
    [SerializeField] private UnityEvent onForceGameOver;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.End))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Time.timeScale = 1f;
        onForceGameOver?.Invoke();

        
    }
}
