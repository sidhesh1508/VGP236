using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject winPanel;

    public int Score { get; private set; }
    public bool HasWon { get; private set; }

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);

        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        if (Time.timeScale == 0f)
            return;

        Score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Points: " + Score;
    }
}