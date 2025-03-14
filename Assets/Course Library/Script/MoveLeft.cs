using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed; // The speed at which the object will move left
    private PlayerController playerControllerScript; // Reference to the PlayerController script attached to the player object 
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Find the player object and get the PlayerController script attached to it
    }
    private void Update()
    {
        if (playerControllerScript.gameOver == false) // Check if the game is not over 
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // Move the object left at the specified speed
        } 
    }
}
