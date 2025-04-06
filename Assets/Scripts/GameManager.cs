using UnityEngine;

public class GameManager : MonoBehaviour
{
    float deltaTime = 0.0f;
    private void Awake()
    {
        // Si ya existe un GameManager, destruye este para evitar duplicados
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        //deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        //Debug.Log("FPS: "+(1.0f / deltaTime));
    }
}