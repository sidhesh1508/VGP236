using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Rigidbody2D player1;
    [SerializeField] private Rigidbody2D player2;

    [SerializeField] private Transform respawnPoint1;
    [SerializeField] private Transform respawnPoint2;

    private float nextDeathTime;
    private bool gameOver;

    private void Start()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateUI();
    }

    public bool IsPlayer(Rigidbody2D body)
    {
        return body != null && (body == player1 || body == player2);
    }

    public void LoseLife()
    {
        // Prevent both players hitting hazards together costing two lives.
        if (gameOver || Time.time < nextDeathTime)
            return;

        if (player1 == null || player2 == null ||
            respawnPoint1 == null || respawnPoint2 == null)
        {
            Debug.LogError("Assign both players and respawn points.", this);
            return;
        }

        nextDeathTime = Time.time + 1f;

        lives--;
        UpdateUI();

        player1.linearVelocity = Vector2.zero;
        player2.linearVelocity = Vector2.zero;

        player1.angularVelocity = 0f;
        player2.angularVelocity = 0f;

        if (lives <= 0)
        {
            gameOver = true;

            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            Time.timeScale = 0f;
            return;
        }

        player1.position = respawnPoint1.position;
        player2.position = respawnPoint2.position;
    }

    private void UpdateUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}