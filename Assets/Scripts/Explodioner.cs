using System.Collections.Generic;
using UnityEngine;

public class Explodioner : MonoBehaviour
{
    private float _explosionForce = 10;
    private float _explosionRadius = 20;

    private List<Rigidbody> _rigidbodyList;

    public void Explode()
    {
        List<Rigidbody> cubeList = GetRigidbodies();

        foreach (Rigidbody body in cubeList)
        {
            body.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetRigidbodies()
    {
        _rigidbodyList = new List<Rigidbody>();

        Collider[] cubeColliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in cubeColliders)
        {
            if (collider.attachedRigidbody != null)
                if (collider.TryGetComponent<Cube>(out _))
                    _rigidbodyList.Add(collider.attachedRigidbody);
        }

        return _rigidbodyList;
    }
}