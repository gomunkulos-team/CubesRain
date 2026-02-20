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
        _cube.CubeTouchedPlatform += ChangeColor;
    }

    public void OnDisable()
    {
        _cube.CubeTouchedPlatform -= ChangeColor;
    }

    private void ChangeColor(Cube cube)
    {
        Renderer cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.7f, 1f);
        _cube.CubeTouchedPlatform -= ChangeColor;
    }
}
