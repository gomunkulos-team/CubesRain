using UnityEngine;

[RequireComponent(typeof(Cube))]

public class RandomColor : MonoBehaviour
{
    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    public void OnEnable()
    {
        _cube.TouchedPlatform += ChangeColor;
    }

    public void OnDisable()
    {
        _cube.TouchedPlatform -= ChangeColor;
    }

    private void ChangeColor(Cube cube)
    {
        if (cube.TryGetComponent(out Renderer cubeRenderer))
        {
            cubeRenderer.material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.7f, 1f);
            _cube.TouchedPlatform -= ChangeColor;
        }
    }
}
