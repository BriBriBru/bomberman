using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] LayerMask blockLayerMask;
    MeshRenderer bombMeshRenderer;

    [Header("Settings")]
    [SerializeField] float timeToDetonate = 3f;
    [SerializeField] float bombLifeTime = 0.3f;
    [SerializeField] int explosionRange = 3;
    [SerializeField] float delayBetweenExplosions = 0.1f;

    void Start()
    {
        bombMeshRenderer = GetComponent<MeshRenderer>();
        Invoke("Explode", timeToDetonate);
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.localPosition, Quaternion.identity);
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));

        bombMeshRenderer.enabled = false;
        gameObject.SetActive(false);

        Destroy(gameObject, bombLifeTime);
    }

    IEnumerator CreateExplosions(Vector3 direction)
    {
        for (int i = 1; i < explosionRange; i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0f, 0.5f, 0f), direction, out hit, i, blockLayerMask);

            if (!hit.collider)
            {
                Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
            }
            else
            {
                break;
            }

            yield return new WaitForSeconds(delayBetweenExplosions);
        }
    }
}
