using UnityEngine;

public class TeleportController : MonoBehaviour
{

    [SerializeField] public GameObject tarjet;
    SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // make the object blink
        sr.color = new Color(0.4f, 0.8f, 1f, Mathf.PingPong(Time.time/2, 1));

    }

}
