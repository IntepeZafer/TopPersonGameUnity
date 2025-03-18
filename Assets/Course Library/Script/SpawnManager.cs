using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefabs; // Obstacle prefab to be spawned 
    public float startDelay; // Delay before the first obstacle prefab is spawned
    public float repeatRate; // Rate at which the obstacle prefab is spawned
    private Vector3 spawnPos = new Vector3(25, 0, 0); // Position to spawn the obstacle prefab at the right side of the screen
    private PlayerController playerControllerScript; // Reference to the PlayerController script attached to the player object

    private void Start()
    {
        //Instantiate(obstaclePrefabs , spawnPos , obstaclePrefabs.transform.rotation); // Spawn the obstacle prefab at the specified position
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // Invoke the SpawnObstacle method repeatedly with the specified delay and repeat rate 
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Find the player object and get the PlayerController script attached to it 
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation); // Spawn the obstacle prefab at the specified position 
        }
    }
}
