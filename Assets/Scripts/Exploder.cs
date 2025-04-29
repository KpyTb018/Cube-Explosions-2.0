using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void ExplodeTarget(float explosionForce, Vector3 explosionPosition,
        float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(explosionPosition, explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        Explode(explosionForce, explosionPosition, explosionRadius, cubes);
        Instantiate(_effect, explosionPosition, Quaternion.identity);
    }

    public void Explode(float explosionForce, Vector3 explosionPosition,
        float explosionRadius, List<Rigidbody> explorableObjects)
    {
        foreach (Rigidbody explorableObject in explorableObjects)
            explorableObject.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
    }
}
