using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // The player's rigidbody
    public float jumpForce; // The force applied to the player when they jump 
    public float gravityModifier; // The gravity modifier applied to the player rigidbody 
    public bool isOnGround; // A flag to check if the player is on the ground
    public bool gameOver; // A flag to check if the game is over
    private Animator playerAnim; // The player's animator component
    /*public ParticleSystem expolitonParticle;*/ // The particle system attached to the player when they die
    public ParticleSystem dirtParticle; // The particle system attached to the ground when the player jumps 
    public GameObject particleSystem;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Get the player's rigidbody component 
        Physics.gravity *= gravityModifier; // Apply the gravity modifier to the gravity vector 
        playerAnim = GetComponent<Animator>(); // Get the player's animator component 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse); // Apply the jump force to the player rigidbody
            isOnGround = false; // Set the isOnGround flag to false
            playerAnim.SetTrigger("Jump_trig"); // Trigger the Jump animation
            dirtParticle.Stop(); // Stop the particle system attached to the ground
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Set the isOnGround flag to true when the player collides with the ground
            dirtParticle.Play(); // Play the particle system attached to the ground 
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true; // Set the gameOver flag to true when the player collides with an obstacle
            playerAnim.SetBool("Death_b", true); // Set the Death animation parameter to true 
            playerAnim.SetInteger("DeathType_int", 1); // Set the DeathType animation parameter to 1
            //expolitonParticle.Play(); // Play the particle system attached to the player
            Instantiate(particleSystem, transform.position, transform.rotation);
        }
        
    }
}
