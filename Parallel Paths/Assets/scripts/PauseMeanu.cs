using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool isPaused = false;

    private void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        if (isPaused || Time.timeScale == 0f)
            return;

        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (!isPaused)
            return;

        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}