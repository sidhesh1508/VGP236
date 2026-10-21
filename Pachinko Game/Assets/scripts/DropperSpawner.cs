using UnityEngine;

public class DropperSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject dropItem = null;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           
            Instantiate(dropItem, transform.position, Quaternion.identity);
        }

    }
}
