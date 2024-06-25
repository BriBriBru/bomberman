using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float explosionDuration = 2f;

    void Start()
    {
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
