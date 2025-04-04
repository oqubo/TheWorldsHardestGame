using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        // Load the first level
        SceneManager.LoadScene("Level01");
    }
    public void exitGame()
    {
        // Exit the game
        Application.Quit();
        Debug.Log("Exit");
    }
    public void level1()
    {
        SceneManager.LoadScene("Level01");
    }
    public void level2()
    {
        SceneManager.LoadScene("Level02");
    }
    public void level3()
    {
        SceneManager.LoadScene("Level03");
    }
    public void level4()
    {
        SceneManager.LoadScene("Level04");
    }
    public void level5()
    {
        SceneManager.LoadScene("Level05");
    }

}
