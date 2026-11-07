using UnityEngine;

public class StartMessage : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private float displaySeconds = 6f;

    private void Start()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);
            Invoke(nameof(HideMessage), displaySeconds);
        }
    }

    private void HideMessage()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);
    }
}