using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public ParticleSystem activateEffect;
    public AudioClip activateSound;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;
        if (!other.CompareTag("Player")) return;

        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.SetCheckpoint(transform);
            activated = true;

            if (activateEffect != null)
            {
                ParticleSystem ps = Instantiate(activateEffect, transform.position, Quaternion.identity);
                ps.Play();
                Destroy(ps.gameObject, 2f);
            }

            if (activateSound != null)
                AudioSource.PlayClipAtPoint(activateSound, transform.position);
        }
    }
}

