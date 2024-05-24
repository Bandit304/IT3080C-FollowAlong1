using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement Components")]
    // Max horizontal speed
    public float movementSpeed;
    // Horizontal movement acceleration
    public float movementAcceleration;
    // Drag when not in air or when not moving
    public float movementDrag;
    public bool isCrouching;
    // Vector representing inputs for horizontal movement
    private Vector3 movementVector;
    // Magnitude of jump force
    public float jumpForce;
    // Sensor to check if player is grounded
    public bool isGrounded;


    [Header("Camera Movement Components")]
    // Camera height
    public float cameraHeight;
    // Mouse Sensitivity
    public float sensitivity;
    // Horizontal Camera Rotation
    public float hRotation;
    // Vertical Camera Rotation
    public float vRotation;

    [Header("Player Components")]
    public Rigidbody rb;
    public Transform playerCamera;

    private void Start() {
        // Initialize Player Components
        rb = GetComponent<Rigidbody>();

        // Throw error for required components that cannot be automatically defined
        if (!playerCamera)
            throw new UnityException("Player camera not defined");
        
        // Set cursor values for camera controls
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update() {
        // Handle Player Movement
        movementVector = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        PlayerMovement();

        // Handle Jump
        if (Input.GetKey(KeyCode.Space))
            PlayerJump();
        
        // Handle Camera Movement
        // Get horizontal rotation
        hRotation += Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;

        // Get vertical rotation
        vRotation -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;
        vRotation = Mathf.Clamp(vRotation, -90f, 90f);

        CameraMovement();
    }

    public void PlayerJump() {
        if (isGrounded)
        {
            isGrounded = false;
            rb.linearDamping = 0;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void PlayerMovement() {
        // Add movement force
        rb.AddForce(movementVector * movementAcceleration, ForceMode.Force);

        // Cap horizontal velocity at movement speed
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (horizontalVelocity.magnitude > movementSpeed) {
            Vector3 limitedVelocity = horizontalVelocity.normalized * movementSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }

        // Apply drag when not in air and not moving
        if (movementVector.magnitude == 0 && isGrounded)
            rb.linearDamping = movementDrag;
        else
            rb.linearDamping = 0;

        // Update Camera Position
        if (!!playerCamera)
            playerCamera.position = transform.position + new Vector3(0, cameraHeight, 0);
    }

    public void CameraMovement() {
        // Rotate Player
        transform.rotation = Quaternion.Euler(0, hRotation, 0);
        // Rotate Camera
        if (!!playerCamera)
            playerCamera.transform.rotation = Quaternion.Euler(vRotation, hRotation, 0);

    }
}
