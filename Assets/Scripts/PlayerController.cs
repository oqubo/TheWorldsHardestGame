using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h, v;
   [SerializeField] private float speed = 5f; // Speed of the player
   [SerializeField] private int life = 3; // Life of the player
   [SerializeField] private GameObject checkpoint; // Checkpoint object


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // Get horizontal input
        v = Input.GetAxis("Vertical"); // Get vertical input
        transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime); // Move the player
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with: " + other.gameObject.tag); // Log the collision


        if (other.gameObject.CompareTag("goal"))
        {
            Debug.Log("Goal reached!"); // Player reached the goal
        }
        if (other.gameObject.CompareTag("checkpoint"))
        {
            checkpoint = other.gameObject; // Set the checkpoint
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            life--;
            if(life==0)
            {
                // Game Over
                Debug.Log("Game Over");
                Destroy(gameObject); // Destroy the player object
            }
            else
            {
                // Player hit by enemy
                Debug.Log("Player hit by enemy. Life left: " + life);
                this.transform.position = checkpoint.transform.position; // Respawn at the checkpoint
            }

        }
        if (other.gameObject.CompareTag("wall"))
        {
                // Player hit by enemy
                Debug.Log("Player hit by enemy. Life left: " + life);
                this.transform.position = checkpoint.transform.position; // Respawn at the checkpoint
        }
    }
}
