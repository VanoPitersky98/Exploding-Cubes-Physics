using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 500f;

    public void Explode(Vector3 explosionPoint, Cube[] cubesToPush)
    {
        foreach (Cube cube in cubesToPush)
        {
            if (cube.TryGetComponent(out Rigidbody rb))
            {
                float sizeMultiplier = cube.transform.localScale.x;
                
                float adaptedForce = _explosionForce * sizeMultiplier;
                float adaptedRadius = _explosionRadius * sizeMultiplier;

                rb.AddExplosionForce(adaptedForce, explosionPoint, adaptedRadius, 1f);
            }
        }
    }
}
