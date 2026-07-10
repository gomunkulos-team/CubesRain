using TMPro;
using UnityEngine;

public class SpawnerInterface : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _numberAllTimeSpawn;
    [SerializeField] TextMeshProUGUI _numberObjectsCreated;
    [SerializeField] TextMeshProUGUI _numberActiveObjects;

    public void Draw(float allValue, float cteatedValue, float activeValue)
    {
        _numberAllTimeSpawn.text = allValue.ToString();
        _numberObjectsCreated.text = cteatedValue.ToString();
        _numberActiveObjects.text = activeValue.ToString();
    }
}
