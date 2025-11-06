using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultsScreen : MonoBehaviour
{
    [Header("Referencias UI (panel final)")]
    public TextMeshProUGUI scoreTextFinal;
    public TextMeshProUGUI fallsTextFinal;
    public TextMeshProUGUI timeTextFinal;

    [Header("Escena del menú principal")]
    public string mainMenuScene = "MainMenu"; // cámbiala por el nombre real

    private void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("No se encontró el GameManager en la escena.");
            return;
        }

        // --- Puntaje total ---
        if (scoreTextFinal != null)
            scoreTextFinal.text = GameManager.Instance.totalScore.ToString();

        // --- Caídas totales ---
        if (fallsTextFinal != null)
            fallsTextFinal.text = GameManager.Instance.totalFalls.ToString();

        // --- Tiempo total ---
        float totalTime = GameManager.Instance.totalTime;
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);
        int milliseconds = Mathf.FloorToInt((totalTime * 1000f) % 1000f);

        if (timeTextFinal != null)
            timeTextFinal.text = $"{minutes:00}:{seconds:00}:{milliseconds:000}";
    }

    // --- Botón para volver al menú principal ---
    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
