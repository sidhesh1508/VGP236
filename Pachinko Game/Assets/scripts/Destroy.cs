using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            GameManager.Instance.ReducePoints();
            Destroy(gameObject);

        }

    }
}
