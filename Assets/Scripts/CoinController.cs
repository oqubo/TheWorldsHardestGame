using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f; // Speed of the coin
    private Vector3 scaleMax = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 scaleMin = new Vector3(0.1f, 0.1f, 0.1f);

    private bool aumentar = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.localScale = scaleMin;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aumentar)
        {
            // Scale the coin up
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, scaleMax, speed * Time.deltaTime);
            if (this.transform.localScale.x >= scaleMax.x - 0.1f)
            {
                aumentar = false;
            }
        }
        else
        {
            // Scale the coin down
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, scaleMin, speed * Time.deltaTime);
            if (this.transform.localScale.x <= scaleMin.x + 0.1f)
            {
                aumentar = true;
            }
        }
    }
}
