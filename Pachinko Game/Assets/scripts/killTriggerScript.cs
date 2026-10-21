using UnityEngine;

public class killTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
