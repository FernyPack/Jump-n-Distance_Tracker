using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 lastPosition;
    public float totalDistanceTravelled;
    public Vector3 initialPosition;
    public float moveSpeed = 6f;
    public float jumpForce = 8f;
    public float gravity = -20f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 startPosition;
    public float distanceTravelled;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        initialPosition = transform.position;
        lastPosition = transform.position;
    }

    void Update()
    {
        MovePlayer();
        ApplyGravity();
        RotateToCameraDirection();
        CalculateDistance();
        float step = Vector3.Distance(transform.position, lastPosition);
        totalDistanceTravelled += step;
        lastPosition = transform.position;

    }

    void MovePlayer()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.right * x + cameraTransform.forward * z;
        move.y = 0f;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            velocity.y = jumpForce;
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void RotateToCameraDirection()
    {
        Vector3 lookDir = cameraTransform.forward;
        lookDir.y = 0;

        if (lookDir.sqrMagnitude > 0.1f)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), 10f * Time.deltaTime);
    }

    void CalculateDistance()
    {
        distanceTravelled = Vector3.Distance(startPosition, transform.position);
    }
}
