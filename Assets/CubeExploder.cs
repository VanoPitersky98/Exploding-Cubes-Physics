using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 500f;

    public void Explode(Vector3 explosionPoint, Cube[] cubesToPush)
    {
        foreach (Cube cube in cubesToPush)
        {
            if (cube.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddExplosionForce(_explosionForce, explosionPoint, _explosionRadius);
            }
        }
    }
}
