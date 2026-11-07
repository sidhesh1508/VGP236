using UnityEngine;

public class FlowerPoints : MonoBehaviour
{
    [SerializeField] private int points = 10;
    [SerializeField] private Rigidbody2D collectingPlayer;
    [SerializeField] private ScoreManager scoreManager;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected || other.isTrigger)
            return;

        if (collectingPlayer == null || scoreManager == null)
            return;

        if (other.attachedRigidbody != collectingPlayer)
            return;

        collected = true;
        scoreManager.AddPoints(points);

        Destroy(gameObject);
    }
}
