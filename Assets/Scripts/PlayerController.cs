using TMPro;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine;
using UnityEditor;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float h, v;
   [SerializeField] private float speed = 5f; // Speed of the player
   [SerializeField] private int life = 3; // Life of the player
   [SerializeField] private int coins = 0; // Coins collected by the player 
   [SerializeField] private GameObject checkpoint; // Checkpoint object
   [SerializeField] private GameObject popupGameOver, popupGameWin; // Game Over and Game Win popups
   [SerializeField] private string nextLevel; // Next level object

  [SerializeField] private TextMeshProUGUI textLifes, textCoins; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textLifes.text = "Lifes: " + life; // Initialize the life text
        textCoins.text = "Coins: " + coins; // Initialize the coins text
        this.transform.position = checkpoint.transform.position; // Set the initial position of the player        

        popupGameOver.SetActive(false); // Hide the Game Over popup
        popupGameWin.SetActive(false); // Hide the Game Win popup
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
        if (other.gameObject.CompareTag("goal"))
        {
            popupGameWin.SetActive(true); // Show the Game Win popup
            Time.timeScale = 0; // Pause the game
            // load the next level after 3 seconds
            StartCoroutine(closeGameWin(3f));

        }
        if (other.gameObject.CompareTag("checkpoint"))
        {
            checkpoint = other.gameObject; // Set the checkpoint
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            life--;
            textLifes.text = "Lifes: " + life; // Update the life text

            if(life==0)
            {
                popupGameOver.SetActive(true); // Show the Game Over popup
                Time.timeScale = 0; // Pause the game
                // load the same level after 3 seconds
                StartCoroutine(closeGameOver(3f));
            }
            else
            {
                this.transform.position = checkpoint.transform.position; // Respawn at the checkpoint
            }

        }
        if (other.gameObject.CompareTag("wall"))
        {
                // Player hit by enemy
                this.transform.position = checkpoint.transform.position; // Respawn at the checkpoint
        }
        if (other.gameObject.CompareTag("coin"))
        {
            coins++;
            textCoins.text = "Coins: " + coins; // Update the coins text

            Destroy(other.gameObject); // Destroy the coin object
        }
        if (other.gameObject.CompareTag("teleport"))
        {
            this.transform.position = other.gameObject.GetComponent<TeleportController>().tarjet.transform.position; // Teleport the player
        }
    }

    private IEnumerator closeGameOver(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Wait for the specified delay
        Time.timeScale = 1; // Resume the game
        popupGameOver.SetActive(false); // Hide the Game Over popup
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene

    }

    private IEnumerator closeGameWin(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Wait for the specified delay
        Time.timeScale = 1; // Resume the game
        popupGameWin.SetActive(false); // Hide the popup
        SceneManager.LoadScene(nextLevel); // Reload the next scene
    }

}
