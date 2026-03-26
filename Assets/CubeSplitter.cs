using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab; 
    [SerializeField] private CubeExploder _exploder; 

    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnMouseDown()
    {
        if (Random.value <= _cube.SplitChance)
        {
            Split();
        }

        Destroy(gameObject);
    }

    private void Split()
    {
        int count = Random.Range(2, 7); 
        Cube[] newCubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            newCubes[i] = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            newCubes[i].Init(_cube.SplitChance, transform.localScale);
        }

        _exploder.Explode(transform.position, newCubes);
    }
}
