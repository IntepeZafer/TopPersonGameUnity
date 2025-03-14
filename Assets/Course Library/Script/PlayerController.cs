using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // The player's rigidbody
    public float jumpForce; // The force applied to the player when they jump 
    public float gravityModifier; // The gravity modifier applied to the player rigidbody 
    public bool isOnGround;
    public bool gameOver;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Get the player's rigidbody component 
        Physics.gravity *= gravityModifier; // Apply the gravity modifier to the gravity vector 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse); // Apply the jump force to the player rigidbody
            isOnGround = false; // Set the isOnGround flag to false
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Set the isOnGround flag to true when the player collides with the ground
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true; // Set the gameOver flag to true when the player collides with an obstacle
        }
        
    }
}
