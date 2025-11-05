using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneByHeight : MonoBehaviour
{
    [Tooltip("Altura en Y a la que el jugador debe llegar para cambiar de escena")]
    public float targetHeight = 20f;

    [Tooltip("Nombre de la escena a cargar (tal cual en Build Settings)")]
    public string sceneToLoad = "Scene 2";

    private bool loaded = false;

    private void Update()
    {
        if (loaded) return;

        if (transform.position.y >= targetHeight)
        {
            loaded = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
