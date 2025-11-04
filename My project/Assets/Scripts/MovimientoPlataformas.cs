using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveDistance = 3f;     // cuánto sube desde su posición inicial
    public float moveSpeed = 2f;        // qué tan rápido sube/baja
    public float waitTime = 0.5f;       // cuánto espera arriba/abajo

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool goingUp = true;
    private float waitCounter = 0f;

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveDistance;
    }

    private void Update()
    {
        // si está esperando, contamos y no nos movemos
        if (waitCounter > 0f)
        {
            waitCounter -= Time.deltaTime;
            return;
        }

        Vector3 goal = goingUp ? targetPos : startPos;
        transform.position = Vector3.MoveTowards(transform.position, goal, moveSpeed * Time.deltaTime);

        // ¿llegamos?
        if (Vector3.Distance(transform.position, goal) < 0.01f)
        {
            goingUp = !goingUp;
            waitCounter = waitTime;
        }
    }

    // esto es para que luego el player viaje con la plataforma
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
