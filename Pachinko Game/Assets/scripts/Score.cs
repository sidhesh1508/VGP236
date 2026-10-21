using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private int points = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            GameManager.Instance.AddPoints(points);

        }
       
    }


}
