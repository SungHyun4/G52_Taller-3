using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeTrigger : MonoBehaviour
{
    public string sceneToLoad = "Scene 2";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SceneManager.LoadScene(sceneToLoad);
    }
}
