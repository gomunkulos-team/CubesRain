using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _repeateRate = 0.3f;
    [SerializeField] private float _positionY = 50f;

    private float _minCoordinate = -90;
    private float _maxCoordinate = 90;
    private float _minLifeTime = 2;
    private float _maxLifeTime = 5;
    private int _poolCapacity = 25;
    private int _poolMaxSize = 25;

    private Coroutine _coroutine;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => ActionOnGet(cube),
            actionOnRelease: (cube) => cube.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void OnEnable()
    {
        _prefab.GetComponent<CollisionDetector>().CubeTouchedPlatform += StartCubeLife;
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeateRate);
    }

    private void ActionOnGet(GameObject cube)
    {
        float positionX = UnityEngine.Random.Range(_minCoordinate, _maxCoordinate);
        float positionZ = UnityEngine.Random.Range(_minCoordinate, _maxCoordinate);

        Vector3 position = new Vector3(positionX, _positionY, positionZ);

        cube.transform.position = position;
        cube.SetActive(true);
        cube.GetComponent<CollisionDetector>().CubeTouchedPlatform += StartCubeLife;
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private void StartCubeLife(Renderer renderer)
    {
        _coroutine = StartCoroutine(WaitRandomTime(renderer));
    }

    private IEnumerator WaitRandomTime(Renderer renderer)
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(_minLifeTime, _maxLifeTime));
        _pool.Release(renderer.gameObject);
    }
}
