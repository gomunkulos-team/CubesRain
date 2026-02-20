using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _repeateRate = 0.3f;
    [SerializeField] private float _positionY = 50f;
    [SerializeField] private Platform _platform;

    private float _minCoordinateX;
    private float _maxCoordinateX;
    private float _minCoordinateZ;
    private float _maxCoordinateZ;
    private float _indent = 1;

    private int _poolCapacity = 25;
    private int _poolMaxSize = 30;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => ActionOnGet(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);


        _minCoordinateX = _platform.MinPositionX + _indent;
        _maxCoordinateX = _platform.MaxPositionX - _indent;
        _minCoordinateZ = _platform.MinPositionZ + _indent;
        _maxCoordinateZ = _platform.MaxPositionZ - _indent;
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeateRate);
    }

    private void ActionOnGet(Cube cube)
    {
        float positionX = Random.Range(_minCoordinateX, _maxCoordinateX);
        float positionZ = Random.Range(_minCoordinateZ, _maxCoordinateZ);

        Vector3 position = new Vector3(positionX, _positionY, positionZ);

        cube.transform.position = position;
        cube.gameObject.SetActive(true);
        cube.CubeTimeIsOver += ReleaseCube;
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private void ReleaseCube(Cube cube)
    {
        cube.CubeTimeIsOver -= ReleaseCube;
        _pool.Release(cube);
    }
}
