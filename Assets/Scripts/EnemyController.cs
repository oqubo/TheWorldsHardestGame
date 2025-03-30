using UnityEngine;

public class Enemigo : MonoBehaviour
{


    [SerializeField] private bool vertical = true; 
    // If true, the enemy moves vertically, else horizontally

    [SerializeField] private float speed = 5f; // Speed of the enemy



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

            
    }

    // Update is called once per frame
    void Update()
    {
        if (vertical)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime); 
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); 
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("wall"))
        {
            // Reverse the direction of the enemy
            speed = -speed;
        }


    }
}
