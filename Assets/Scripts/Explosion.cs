using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float explosionDuration = 2f;

    void Start()
    {
        Destroy(gameObject, explosionDuration);
    }
}
