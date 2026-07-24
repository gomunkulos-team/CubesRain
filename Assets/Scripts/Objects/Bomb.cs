using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Transparency))]
[RequireComponent(typeof(Explodioner))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Bomb : MonoBehaviour
{
    private Transparency _transparency;
    private Explodioner _explodioner;
    private Rigidbody _rigidbody;

    private float _minLifeTime = 2;
    private float _maxLifeTime = 5;

    public event Action<Bomb> TimeIsOver;

    private void Awake()
    {
        _transparency = GetComponent<Transparency>();
        _explodioner = GetComponent<Explodioner>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        float timer = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);

        StartCoroutine(StartExplosionCount(timer));
        _transparency.FaidInTime(timer);
    }

    private IEnumerator StartExplosionCount(float time)
    {
        yield return new WaitForSeconds(time);
        _explodioner.Explode();
        TimeIsOver?.Invoke(this);
    }
}
