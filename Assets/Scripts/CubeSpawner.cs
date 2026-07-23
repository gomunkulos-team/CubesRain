using System;
using System.Collections;
using UnityEngine;

public class CubeSpawner : GenericSpawner<Cube>
{
    [SerializeField] private Platform _platform;

    public event Action<Transform> CubeReleased;

    private float _repeateRate = 0.3f;
    private float _positionY = 50f;

    private float _minCoordinateX;
    private float _maxCoordinateX;
    private float _minCoordinateZ;
    private float _maxCoordinateZ;

    private float _indent = 2;

    private void Start()
    {
        _minCoordinateX = _platform.MinPositionX + _indent;
        _maxCoordinateX = _platform.MaxPositionX - _indent;
        _minCoordinateZ = _platform.MinPositionZ + _indent;
        _maxCoordinateZ = _platform.MaxPositionZ - _indent;

       StartCoroutine(StartRepeatSpawn(_repeateRate));
    }

    protected override void Spawn(Cube cube)
    {
        base.Spawn(cube);

        float positionX = UnityEngine.Random.Range(_minCoordinateX, _maxCoordinateX);
        float positionZ = UnityEngine.Random.Range(_minCoordinateZ, _maxCoordinateZ);

        Vector3 position = new Vector3(positionX, _positionY, positionZ);

        cube.transform.position = position;
        cube.gameObject.SetActive(true);
        cube.CubeTimeIsOver += ReleaseCube;
    }

    private void ReleaseCube(Cube cube)
    {
        cube.CubeTimeIsOver -= ReleaseCube;
        GetCubePosition(cube);
        Release(cube);
    }

    private IEnumerator StartRepeatSpawn(float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);

        while (enabled)
        {
            yield return wait;
            Get();
        }
    }

    private void GetCubePosition(Cube cube)
    {
        CubeReleased?.Invoke(cube.transform);
    }
}
