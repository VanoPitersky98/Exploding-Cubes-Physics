using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube[] Spawn(Cube parentCube)
    {
        BoxCollider parentCollider = parentCube.GetComponent<BoxCollider>();
        if (parentCollider != null)
        {
            parentCollider.enabled = false;
        }

        int count = Random.Range(2, 7);
        Cube[] newCubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * parentCube.transform.localScale.x * 0.5f;
            Vector3 spawnPosition = parentCube.transform.position + randomOffset;

            spawnPosition.y = Mathf.Max(spawnPosition.y, parentCube.transform.position.y);

            newCubes[i] = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
            newCubes[i].Init(parentCube.SplitChance, parentCube.transform.localScale);

            if (newCubes[i].TryGetComponent<Renderer>(out Renderer renderer))
            {
                renderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }

        return newCubes;
    }
}
