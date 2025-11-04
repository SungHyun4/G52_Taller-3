using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Totales acumulados")]
    public int totalScore = 0;
    public int totalFalls = 0;
    public int totalCollected = 0;
    public float totalTime = 0f;

    private bool countingTime = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (countingTime)
            totalTime += Time.deltaTime;
    }

    // --- Métodos públicos ---
    public void AddScore(int amount)
    {
        totalScore += amount;
        if (totalScore < 0) totalScore = 0; // evita números negativos si quieres
    }

    public void AddFall() => totalFalls++;

    public void AddCollected() => totalCollected++;

    public void StopCountingTime() => countingTime = false;
}
