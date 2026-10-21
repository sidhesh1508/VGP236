using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GroundCheck groundCheck = null;
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpSpeed = 10.0f;
    [SerializeField]
    private Rigidbody2D rigidbody=null;
    private float desiredSpeed = 0.0f;
    //Player input hookups
    private PlayerInputs playerInput = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;

    private Vector3 lastSafePosition = Vector3.zero;
    private void Awake()
    {
        playerInput = new PlayerInputs();
        moveAction = playerInput.Player.Move;
        jumpAction = playerInput.Player.Jump;
        jumpAction.performed += OnJump;
        lastSafePosition = transform.position;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        desiredSpeed = moveAction.ReadValue<Vector2>().x * moveSpeed;
        if(groundCheck.IsGrounded())
        {
            lastSafePosition = transform.position;
        }
    }
    private void FixedUpdate()
    {
        rigidbody.linearVelocityX = desiredSpeed;
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsGrounded() && rigidbody.linearVelocityY < 0.1f)
        {
            rigidbody.linearVelocityY = jumpSpeed;
        }
    }
    public void RespawnPlayer()
    {
        transform.position = lastSafePosition;
        rigidbody.linearVelocity = Vector2.zero;
    }
}
