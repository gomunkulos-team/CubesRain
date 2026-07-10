using System;
using UnityEngine;
using UnityEngine.Pool;

public class GenericSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    private ObjectPool<T> _pool;

    private int _poolCapacity = 25;
    private int _poolMaxSize = 30;
    private int _allTimeObjectSpawned = 0;

    public event Action<int> AllTimeSpawnedObjectChanched;
    public event Action<int> CreatedObjectChanched;
    public event Action<int> ActiveObjectChanched;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (@object) => Spawn(@object),
            actionOnRelease: (@object) => @object.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    protected virtual void Spawn(T @object)
    {
        @object.gameObject.SetActive(true);
        _allTimeObjectSpawned++;
        ActiveObjectChanched?.Invoke(_pool.CountActive);
        CreatedObjectChanched?.Invoke(_pool.CountAll);
        AllTimeSpawnedObjectChanched?.Invoke(_allTimeObjectSpawned);
    }

    protected void Release(T @object)
    {
        _pool.Release(@object);
        ActiveObjectChanched?.Invoke(_pool.CountActive);
    }

    protected void Get()
    {
        _pool.Get();
    }

    protected void SetPosition(T @object, Vector3 position)
    {
        @object.transform.position = position;
    }

    protected T GetObject()
    {
        return _pool.Get();
    }
}
