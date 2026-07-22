using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explodioner : MonoBehaviour
{
    private float _explosionForce = 100f;
    private float _explosionRadius = 50;

    private List<Rigidbody> _rigidbodyList;

    public void Explode()
    {
        Debug.Log("BAM");

        List<Rigidbody> cubeList = GetRigidbodies();

        Debug.Log("Количество затронутых кубов: " + cubeList.Count);

        foreach (Rigidbody body in cubeList)
        {
            body.AddExplosionForce(_explosionForce, transform.position, _explosionForce, 1.1f, ForceMode.Impulse);
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