using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //if a variable is public we can assign it values in unity
    //if a variable is private we cannot see it on the unity
    //After serializeing we can assign it if it is private
    //Pascal case is where all the first letters of each word is capitalized
    //MyClass
    //MyFunction
    //Camel Case is where the first  word is all lower case, 
    //but every other word is capital first letter
    // used for member variables, function variables, and local vairables
    //myVariable
    //myLocalVariable
    //one exception, can include -for member variable
    //_myPrivateVariable
    //unity ignores the underscore 
    //mMyMemberVariable // came case, iMyInt, fMyFloat, dMyDouble, lMyLong,bMyBool,gMyGlobal,sMyStatic
    //my_local_variable - snake case 
    [SerializeField]
    private GameObject dropItem = null;
    [SerializeField]
    private float moveSpeed = 2.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spawner Space is pressed");
            Instantiate(dropItem, transform.position, Quaternion.identity);
        }
        Vector3 moveDirection = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            moveDirection.y = moveSpeed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -moveSpeed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -moveSpeed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            moveDirection.x = moveSpeed;
        }
        transform.position += moveDirection * Time.deltaTime;
    }
}
