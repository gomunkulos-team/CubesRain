using TMPro;
using UnityEngine;

public class SpawnerInterface : MonoBehaviour
{
    [SerializeField] private GenericSpawner<MonoBehaviour> _spawner;

    [SerializeField] TextMeshProUGUI _numberAllTimeSpawn;
    [SerializeField] TextMeshProUGUI _numberObjectsCreated;
    [SerializeField] TextMeshProUGUI _numberActiveObjects;


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
