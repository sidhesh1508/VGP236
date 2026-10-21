using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        //requires at least one object to habe a rigid body
        if(collision!=null  &&collision.gameObject!=null)

        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Something Hit mee");
    }
}
