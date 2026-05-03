using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 500f;

    public void ExplodeCubes(Vector3 explosionPoint, float explodingCubeScale, Cube[] cubesToPush)
    {
        float forceMultiplier = 1f / explodingCubeScale;

        foreach (Cube cube in cubesToPush)
        {
            if (cube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce * forceMultiplier, explosionPoint, _explosionRadius * forceMultiplier, 1f);
            }
        }
    }

    public void ExplodeArea(Vector3 explosionPoint, float explodingCubeScale)
    {
        float inverseMultiplier = 1f / explodingCubeScale;

        float finalForce = _explosionForce * inverseMultiplier;
        float finalRadius = _explosionRadius * inverseMultiplier;

        Collider[] colliders = Physics.OverlapSphere(explosionPoint, finalRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(finalForce, explosionPoint, finalRadius, 1f);
            }
        }
    }
}
