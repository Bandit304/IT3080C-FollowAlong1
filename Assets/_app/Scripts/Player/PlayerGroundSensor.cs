using UnityEngine;

public class PlayerGroundSensor : MonoBehaviour
{
    [Header("Ground Sensing Components")]
    // Player's Character Controller
    public CharacterController controller;
    // Number of ground objects being sensed
    [SerializeField]
    private int groundCount;

    void Start()
    {
        // Get CharacterController from Player object
        controller = GetComponentInParent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Track number of ground objects are being sensed
        if (other.CompareTag("Ground"))
            groundCount++;

        // Update isGrounded flag
        updateIsGrounded();
    }

    void OnTriggerExit(Collider other)
    {
        // Track number of ground objects are being sensed
        if (other.CompareTag("Ground"))
            groundCount--;
        
        // Update isGrounded flag
        updateIsGrounded();
    }

    private void updateIsGrounded()
    {
        // If no ground is sensed, set is grounded flag to false. Otherwise, set to true.
        controller.isGrounded = groundCount != 0;
    }
}
