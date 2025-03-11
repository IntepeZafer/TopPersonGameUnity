using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed; // The speed at which the object will move left
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // Move the object left at the specified speed
    }
}
