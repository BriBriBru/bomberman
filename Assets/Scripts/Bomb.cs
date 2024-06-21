using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject explosionPrefab;
    MeshRenderer bombMeshRenderer;

    [Header("Settings")]
    [SerializeField] float timeToDetonate = 3f;
    [SerializeField] float bombLifeTime = 0.3f;
    [SerializeField] float explosionDuration = 2f;

    void Start()
    {
        bombMeshRenderer = GetComponent<MeshRenderer>();
        Invoke("Explode", timeToDetonate);
    }

    void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.localPosition, Quaternion.identity);
        bombMeshRenderer.enabled = false;
        gameObject.SetActive(false);
        Destroy(explosion, explosionDuration);
        Destroy(gameObject, bombLifeTime);
    }
}
