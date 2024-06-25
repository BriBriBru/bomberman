using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        ParticleSystem explosionParticles = GetComponentInChildren<ParticleSystem>();
        float explosionDuration = explosionParticles.main.duration;

        Destroy(gameObject, explosionDuration);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.DestroyPlayer(other.gameObject);
        }
    }
}
