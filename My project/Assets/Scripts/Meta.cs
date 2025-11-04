using UnityEngine;

public class FinalGoalStar : MonoBehaviour
{
    [Header("UI final")]
    [Tooltip("Panel de Canvas que muestra puntos, caídas y tiempo. Déjalo desactivado al inicio.")]
    public GameObject finalPanel;

    [Header("Partículas de la meta (estrella / brillo)")]
    public ParticleSystem starParticles;

    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;
        if (!other.CompareTag("Player")) return;

        finished = true;

        // 1) parar el tiempo global del juego
        if (GameManager.Instance != null)
            GameManager.Instance.StopCountingTime();

        // 2) reproducir partículas de la estrella
        if (starParticles != null)
            starParticles.Play();

        // 3) mostrar el panel final
        if (finalPanel != null)
            finalPanel.SetActive(true);
        else
            Debug.LogWarning("FinalGoalStar: no hay panel asignado en el inspector.");
    }
}
