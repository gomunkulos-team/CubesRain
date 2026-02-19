using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private Renderer _renderer;

    public event Action<Renderer> CubeTouchedPlatform;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter()
    {
        CubeTouchedPlatform?.Invoke(_renderer);
    }
}
