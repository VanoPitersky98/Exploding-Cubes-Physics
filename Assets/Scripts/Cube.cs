using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public float SplitChance { get; private set; } = 1.0f;
    public Renderer Renderer => _renderer;

    public void Init(float parentChance, Vector3 parentScale)
    {
        SplitChance = parentChance / 2f;
        transform.localScale = parentScale / 2f;
    }
}
