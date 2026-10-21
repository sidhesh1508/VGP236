using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField]
    private int points = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collect points
        GameManager.Instance.AddPoints(points);
        //Destroy pickup
        Destroy(gameObject);
    }
}
