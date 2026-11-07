using UnityEngine;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player1;
    [SerializeField] private Rigidbody2D player2;
    [SerializeField] private Collider2D exitZone;

    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int requiredPoints = 100;

    [SerializeField] private TMP_Text doorMessage;
    [SerializeField] private GameObject winPanel;

    private bool gameEnded = false;

    private void Start()
    {
        if (doorMessage != null)
            doorMessage.text = "";

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    private void Update()
    {
        if (gameEnded || Time.timeScale == 0f)
            return;

        if (player1 == null || player2 == null ||
            exitZone == null || scoreManager == null)
            return;

        bool firstAtDoor = player1.IsTouching(exitZone);
        bool secondAtDoor = player2.IsTouching(exitZone);

        if (!firstAtDoor && !secondAtDoor)
        {
            ShowMessage("");
            return;
        }

        if (scoreManager.Score < requiredPoints)
        {
            ShowMessage(
                "Collect " + requiredPoints + " points to finish!\n" +
                "Current points: " + scoreManager.Score
            );

            return;
        }

        if (!firstAtDoor || !secondAtDoor)
        {
            ShowMessage("Wait for your partner!");
            return;
        }

        gameEnded = true;
        ShowMessage("");

        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    private void ShowMessage(string message)
    {
        if (doorMessage != null)
            doorMessage.text = message;
    }
}