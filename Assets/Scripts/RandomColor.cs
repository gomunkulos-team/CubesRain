using UnityEngine;

[RequireComponent(typeof(CollisionDetector))]

public class RandomColor : MonoBehaviour
{
    private CollisionDetector _collisionDetector;

    private void Awake()
    {
        _collisionDetector = GetComponent<CollisionDetector>();
    }

    public void OnEnable()
    {
        _collisionDetector.CubeTouchedPlatform += ChangeColor;
    }

    public void OnDisable()
    {
        _collisionDetector.CubeTouchedPlatform -= ChangeColor;
    }

    private void ChangeColor(Renderer renderer)
    {
        renderer.material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.7f, 1f);
        _collisionDetector.CubeTouchedPlatform -= ChangeColor;
    }
}
