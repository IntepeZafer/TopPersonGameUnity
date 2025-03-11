using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth; // The width of the background object to repeat 

    private void Start()
    {
        startPos = transform.position; // Store the starting position of the background object 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Get the width of the background object 
    }
    private void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos; // Reset the position of the background object to the starting position
        }
    }
}
