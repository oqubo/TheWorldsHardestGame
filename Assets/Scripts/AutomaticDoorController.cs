using Unity.VisualScripting;
using UnityEngine;



public class AutomaticDoorController : MonoBehaviour
{


[SerializeField] private float speed = 1f;

Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
         
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            speed = -speed;
        }
    }
}
