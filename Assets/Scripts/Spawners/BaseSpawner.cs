using System;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    public abstract event Action<int> AllTimeSpawnedObjectChanched;
    public abstract event Action<int> CreatedObjectChanched;
    public abstract event Action<int> ActiveObjectChanched;
}
