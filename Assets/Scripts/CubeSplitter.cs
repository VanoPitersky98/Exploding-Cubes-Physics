using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExploder _exploder;

    private void OnEnable() =>
        _raycaster.Hit += HandleHit;

    private void OnDisable() =>
        _raycaster.Hit -= HandleHit;

    private void HandleHit(Transform hitTransform)
    {
        if (hitTransform.TryGetComponent(out Cube cube))
        {
            Vector3 position = cube.transform.position;
            float currentScale = cube.transform.localScale.x;

            if (Random.value <= cube.SplitChance)
            {
                Cube[] newCubes = _spawner.Spawn(cube);
                _exploder.ExplodeCubes(position, currentScale, newCubes);
            }
            else
            {
                _exploder.ExplodeArea(position, currentScale);
            }

            Destroy(cube.gameObject);
        }
    }
}
