using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;

    public event Action<Transform> Hit; 

    private void OnEnable() =>
        _inputReader.Clicked += ThrowRay;

    private void OnDisable() =>
        _inputReader.Clicked -= ThrowRay;

    private void ThrowRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Hit?.Invoke(hit.transform);
        }
    }
}