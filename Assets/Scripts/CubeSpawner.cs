using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6; 

    public Cube[] Spawn(Cube parentCube)
    {
        if (parentCube.TryGetComponent(out BoxCollider parentCollider))
        {
            parentCollider.enabled = false;
        }

        int count = Random.Range(_minCubes, _maxCubes + 1);
        Cube[] newCubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * parentCube.transform.localScale.x * 0.5f;
            Vector3 spawnPosition = parentCube.transform.position + randomOffset;
            spawnPosition.y = Mathf.Max(spawnPosition.y, parentCube.transform.position.y);

            newCubes[i] = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
            newCubes[i].Init(parentCube.SplitChance, parentCube.transform.localScale);

            newCubes[i].Renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }

        return newCubes;
    }
}
