using System;
using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    private float _minLifeTime = 2;
    private float _maxLifeTime = 5;

    public event Action<Cube> CubeTouchedPlatform;
    public event Action<Cube> CubeTimeIsOver;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _renderer.material.color = Color.yellow;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out _))
        {
            CubeTouchedPlatform?.Invoke(this);
            StartCoroutine(StartDeathCount());
        }
    }

    private IEnumerator StartDeathCount()
    {
        float lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        yield return new WaitForSeconds(lifeTime);
        CubeTimeIsOver?.Invoke(this);
    }
}
