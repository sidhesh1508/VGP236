using UnityEngine;

public class KillVolume : MonoBehaviour
{
    [SerializeField] private LivesManager livesManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger || livesManager == null)
            return;

        if (livesManager.IsPlayer(other.attachedRigidbody))
        {
            livesManager.LoseLife();
        }
    }
}