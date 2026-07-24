using System;
using UnityEngine;

public abstract class EventForSpawners : MonoBehaviour
{
    public abstract event Action<int> AllTimeSpawnedObjectChanched;
    public abstract event Action<int> CreatedObjectChanched;
    public abstract event Action<int> ActiveObjectChanched;
}
