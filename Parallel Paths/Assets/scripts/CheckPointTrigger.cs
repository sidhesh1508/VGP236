using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
    

    [SerializeField] private Rigidbody2D player1;
    [SerializeField] private Rigidbody2D player2;

    [SerializeField] private Transform respawnPoint1;
    [SerializeField] private Transform respawnPoint2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
            return;

        Rigidbody2D body = other.attachedRigidbody;

        if (body == null || (body != player1 && body != player2))
            return;

        if (player1 == null || player2 == null ||
            respawnPoint1 == null || respawnPoint2 == null)
        {
            Debug.LogError("Assign both players and respawn points.", this);
            return;
        }

        player1.position = respawnPoint1.position;
        player2.position = respawnPoint2.position;

        player1.linearVelocity = Vector2.zero;
        player2.linearVelocity = Vector2.zero;

        player1.angularVelocity = 0f;
        player2.angularVelocity = 0f;
    }
}
