using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropperMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.0f;
    
    void Update()
    {
        Debug.Log("Working");
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y = moveSpeed;
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y = -moveSpeed;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x = -moveSpeed;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x = moveSpeed;
        }
        transform.position += moveDirection * Time.deltaTime;
    }
   
}