using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : GenericSpawner<Cube>
{
    [SerializeField] private Platform _platform;

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

       StartRepeatSpawn(_repeateRate);
    }

    protected override void Spawn(Cube cube)
    {
        float positionX = Random.Range(_minCoordinateX, _maxCoordinateX);
        float positionZ = Random.Range(_minCoordinateZ, _maxCoordinateZ);

        Vector3 position = new Vector3(positionX, _positionY, positionZ);

        cube.transform.position = position;
        cube.gameObject.SetActive(true);
        cube.CubeTimeIsOver += ReleaseCube;
    }

    private void ReleaseCube(Cube cube)
    {
        cube.CubeTimeIsOver -= ReleaseCube;
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
}
