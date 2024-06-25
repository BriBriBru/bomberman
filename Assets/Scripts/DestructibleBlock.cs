using UnityEngine;

public class DestructibleBlock : MonoBehaviour
{
    [SerializeField] GameObject blockDestructionParticlePrefab;

    public void DestroyBlock()
    {
        GameObject particleObject = Instantiate(blockDestructionParticlePrefab, transform.position, transform.rotation);
        ParticleSystem blockDestructionParticle = particleObject.GetComponent<ParticleSystem>();
        blockDestructionParticle.Play();

        Destroy(gameObject);
        Destroy(particleObject, blockDestructionParticle.main.duration);
    }
}
