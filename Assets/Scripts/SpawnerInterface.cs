using TMPro;
using UnityEngine;

public class SpawnerInterface : MonoBehaviour
{
    [SerializeField] GenericSpawner<MonoBehaviour> _genericSpawner;

    [SerializeField] TextMeshProUGUI _numberAllTimeSpawn;
    [SerializeField] TextMeshProUGUI _numberObjectsCreated;
    [SerializeField] TextMeshProUGUI _numberActiveObjects;

    private void OnEnable()
    {
        _genericSpawner.AllTimeSpawnedObjectChanched += UpdateAllTimeSpawnNumber;
        _genericSpawner.CreatedObjectChanched += UpdateObjectCreatedNumber;
        _genericSpawner.ActiveObjectChanched += UpdateActiveObjects;
    }

    private void OnDisable()
    {
        _genericSpawner.AllTimeSpawnedObjectChanched -= UpdateAllTimeSpawnNumber;
        _genericSpawner.CreatedObjectChanched -= UpdateObjectCreatedNumber;
        _genericSpawner.ActiveObjectChanched -= UpdateActiveObjects;
    }

    private void UpdateAllTimeSpawnNumber(int number)
    {
        _numberAllTimeSpawn.text = number.ToString();
    }

    private void UpdateObjectCreatedNumber(int number)
    {
        _numberObjectsCreated.text = number.ToString();
    }

    private void UpdateActiveObjects(int number)
    {
        _numberActiveObjects.text = number.ToString();
    }
}
