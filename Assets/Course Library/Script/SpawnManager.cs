using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    public float startDelay;
    public float repeatRate;
    private Vector3 spawnPos = new Vector3(25, 0, 0); // Position to spawn the obstacle prefab at the right side of the screen

    private void Start()
    {
        //Instantiate(obstaclePrefabs , spawnPos , obstaclePrefabs.transform.rotation); // Spawn the obstacle prefab at the specified position
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
    }
}
