using TMPro;
using UnityEngine;

public class SpawnerInterface : MonoBehaviour
{
    [SerializeField] private BaseSpawner _spawner;

    [SerializeField] private TextMeshProUGUI _numberAllTimeSpawn;
    [SerializeField] private TextMeshProUGUI _numberObjectsCreated;
    [SerializeField] private TextMeshProUGUI _numberActiveObjects;

    private string _textAllTime = "All Time: ";
    private string _textCreated = "Created: ";
    private string _textActive = "Active: ";

    private void OnEnable()
    {
        if (_spawner == null) return;

        _spawner.AllTimeSpawnedObjectChanched += UpdateAllTimeSpawnNumber;
        _spawner.CreatedObjectChanched += UpdateObjectCreatedNumber;
        _spawner.ActiveObjectChanched += UpdateActiveObjects;
    }

    private void OnDisable()
    {
        if (_spawner == null) return;

        _spawner.AllTimeSpawnedObjectChanched -= UpdateAllTimeSpawnNumber;
        _spawner.CreatedObjectChanched -= UpdateObjectCreatedNumber;
        _spawner.ActiveObjectChanched -= UpdateActiveObjects;
    }

    private void UpdateAllTimeSpawnNumber(int number)
    {
        _numberAllTimeSpawn.text = _textAllTime + number.ToString();
    }

    private void UpdateObjectCreatedNumber(int number)
    {
        _numberObjectsCreated.text = _textCreated + number.ToString();
    }

    private void UpdateActiveObjects(int number)
    {
        _numberActiveObjects.text = _textActive + number.ToString();
    }
}