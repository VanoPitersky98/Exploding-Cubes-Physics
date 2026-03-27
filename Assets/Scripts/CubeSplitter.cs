using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExploder _exploder;

    private void OnEnable() => _raycaster.OnHit += HandleHit;
    private void OnDisable() => _raycaster.OnHit -= HandleHit;

    private void HandleHit(Transform hitTransform)
    {
        if (hitTransform.TryGetComponent(out Cube cube))
        {
            Vector3 explosionPosition = cube.transform.position;

            if (Random.value <= cube.SplitChance)
            {
                Cube[] newCubes = _spawner.Spawn(cube);
                _exploder.Explode(explosionPosition, newCubes);
            }
            else
            {

                float shockwaveRadius = 5f;

                Collider[] nearbyColliders = Physics.OverlapSphere(explosionPosition, shockwaveRadius);

                foreach (Collider hitCollider in nearbyColliders)
                {
                    if (hitCollider.TryGetComponent(out Cube otherCube) && otherCube != cube)
                    {
                        _exploder.Explode(explosionPosition, new Cube[] { otherCube });
                    }
                }
            }

            Destroy(cube.gameObject);
        }
    }
}
