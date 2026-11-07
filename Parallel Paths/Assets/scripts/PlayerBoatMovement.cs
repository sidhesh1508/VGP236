using UnityEngine;

public class PlayerBoatMovement : MonoBehaviour
{
    [SerializeField] private Boat boat;
    [SerializeField] private Rigidbody2D playerBody;

    void LateUpdate()
    {
        if (boat != null && boat.IsOnBoat(playerBody))
        {
            transform.position += boat.MovementDelta;
        }
    }
}