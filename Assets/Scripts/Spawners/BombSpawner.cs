using UnityEngine;

public class BombSpawner : GenericSpawner<Bomb>
{
    [SerializeField] CubeSpawner _cubeSpawner;

    private void OnEnable()
    {
        _cubeSpawner.CubeReleased += SpawnBomb;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeReleased -= SpawnBomb;
    }

    protected override void Spawn(Bomb bomb)
    {
        base.Spawn(bomb);
        bomb.TimeIsOver += ReleaseBomb;
    }

    private void SpawnBomb(Transform cubePosition)
    {
        Bomb bomb = GetObject();
        bomb.transform.position = cubePosition.position;
    }

    private void ReleaseBomb(Bomb bomb)
    {
        bomb.TimeIsOver -= ReleaseBomb;
        Release(bomb);
    }
}