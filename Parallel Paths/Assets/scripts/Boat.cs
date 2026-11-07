using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float moveSpeed = 2.0f;

    [SerializeField] private Rigidbody2D player1;
    [SerializeField] private Rigidbody2D player2;

    private HashSet<Collider2D> passengers = new HashSet<Collider2D>();
    private bool journeyStarted = false;

    public Vector3 MovementDelta { get; private set; }

    void Update()
    {
        Debug.Log(
    "P1: " + IsOnBoat(player1) +
    " | P2: " + IsOnBoat(player2) +
    " | Started: " + journeyStarted +
    " | Destination: " + destination
);
        Vector3 previousPosition = transform.position;

        if (!journeyStarted && IsOnBoat(player1) && IsOnBoat(player2))
        {
            journeyStarted = true;
        }

        if (journeyStarted && destination != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destination.position,
                moveSpeed * Time.deltaTime
            );
        }

        MovementDelta = transform.position - previousPosition;
    }

    public bool IsOnBoat(Rigidbody2D player)
    {
        if (player == null)
            return false;

        foreach (Collider2D passenger in passengers)
        {
            if (passenger != null && passenger.attachedRigidbody == player)
                return true;
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore GroundCheck trigger colliders.
        Debug.Log("Boat detected: " + other.name
    + " | Trigger: " + other.isTrigger
    + " | Body: " + other.attachedRigidbody);
        if (other.isTrigger)
            return;

        Rigidbody2D body = other.attachedRigidbody;

        if (body != null && (body == player1 || body == player2))
        {
            passengers.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        passengers.Remove(other);
    }
}


