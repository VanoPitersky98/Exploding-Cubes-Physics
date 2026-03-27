using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public float SplitChance { get; private set; } = 1.0f;

    private void Start()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void Init(float parentChance, Vector3 parentScale)
    {
        SplitChance = parentChance / 2f;
        transform.localScale = parentScale / 2f;
    }
}
