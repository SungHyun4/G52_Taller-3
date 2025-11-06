using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Paneles del Menú")]
    public GameObject mainMenuPanel;      // Panel principal con los botones JUGAR e INSTRUCCIONES
    public GameObject instructionsPanel;  // Panel o Canvas de instrucciones

    [Header("Nombre de la escena del juego")]
    public string gameSceneName = "Scene 1"; // Cambia al nombre real de tu escena

    // --- Botón JUGAR ---
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // --- Botón INSTRUCCIONES ---
    public void ShowInstructions()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (instructionsPanel != null) instructionsPanel.SetActive(true);
    }

    // --- Botón VOLVER ---
    public void BackToMenu()
    {
        if (instructionsPanel != null) instructionsPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }

    // --- Botón SALIR (opcional) ---
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado (solo visible en build).");
    }
}
