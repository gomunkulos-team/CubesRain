using UnityEngine;

public class BombSpawner : GenericSpawner<Bomb>
{
    [SerializeField] Cube _cubePrefab;

    private void OnEnable()
    {
        _cubePrefab.CubeTimeIsOver += SetPosition;
    }

    protected override void Spawn(Bomb bomb)
    {
        base.Spawn(bomb);
    }

    private void SetPosition(Cube cube)
    {
        Bomb bomb = GetObject();
        _cubePrefab.transform.position = cube.transform.position;
    }
}
