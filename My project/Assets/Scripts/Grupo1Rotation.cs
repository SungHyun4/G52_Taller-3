using UnityEngine;

public class PlatformGroupOrbit : MonoBehaviour
{
    [Header("Velocidad de rotación (grados por segundo)")]
    public float rotationSpeed = 25f;

    [Header("Sentido de giro")]
    public bool clockwise = true;

    private Transform torreCentral;

    private void Start()
    {
        // Busca automáticamente un objeto llamado "TorreCentral"
        GameObject torreObj = GameObject.Find("TorreCentral");
        if (torreObj != null)
        {
            torreCentral = torreObj.transform;
        }
        else
        {
            Debug.LogWarning(" No se encontró un objeto llamado 'TorreCentral' en la escena.");
        }
    }

    private void Update()
    {
        if (torreCentral == null) return;

        // Determinar dirección
        float dir = clockwise ? 1f : -1f;

        // Girar alrededor del eje Y de la torre
        transform.RotateAround(torreCentral.position, Vector3.up, dir * rotationSpeed * Time.deltaTime);
    }
}
