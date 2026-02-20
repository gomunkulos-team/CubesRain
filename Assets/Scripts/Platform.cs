using UnityEngine;
using System.Linq;

[RequireComponent(typeof(MeshCollider))]

public class Platform : MonoBehaviour
{
    private MeshCollider _meshCollider;

    public float MinPositionX { get; private set; }
    public float MinPositionZ { get; private set; }
    public float MaxPositionX { get; private set; }
    public float MaxPositionZ { get; private set; }


    private void Awake()
    {
        _meshCollider = GetComponent<MeshCollider>();

        Vector3[] meshCorners = GetWorldVertices();

        MinPositionX = GetMinXCoordinate(meshCorners);
        MinPositionZ = GetMinZCoordinate(meshCorners);
        MaxPositionX = GetMaxXCoordinate(meshCorners);
        MaxPositionZ = GetMaxZCoordinate(meshCorners);
    }

    private Vector3[] GetWorldVertices()
    {
        Vector3[] localCorners = _meshCollider.sharedMesh.vertices;
        Vector3[] worldCorners = new Vector3[localCorners.Length];

        for (int i = 0; i < localCorners.Length; i++)
        {
            worldCorners[i] = transform.TransformPoint(localCorners[i]);
        }

        return worldCorners;
    }

    private float GetMinXCoordinate(Vector3[] cornrers)
    {
        float buferNumber = float.MaxValue;

        foreach (Vector3 corner in cornrers)
        {
            if (corner.x < buferNumber)
                buferNumber = corner.x;
        }

        return buferNumber;
    }

    private float GetMaxXCoordinate(Vector3[] cornrers)
    {
        float buferNumber = float.MinValue;

        foreach (Vector3 corner in cornrers)
        {
            if (corner.x > buferNumber)
                buferNumber = corner.x;
        }

        return buferNumber;
    }

    private float GetMinZCoordinate(Vector3[] cornrers)
    {
        float buferNumber = float.MaxValue;

        foreach (Vector3 corner in cornrers)
        {
            if (corner.z < buferNumber)
                buferNumber = corner.z;
        }

        return buferNumber;
    }

    private float GetMaxZCoordinate(Vector3[] cornrers)
    {
        float buferNumber = float.MinValue;

        foreach (Vector3 corner in cornrers)
        {
            if (corner.z > buferNumber)
                buferNumber = corner.z;
        }

        return buferNumber;
    }
}
