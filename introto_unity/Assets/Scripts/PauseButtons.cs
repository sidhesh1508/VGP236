using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    private bool isPaused = false;
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;
    }
}
