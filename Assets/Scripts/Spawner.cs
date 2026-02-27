using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private ColorRandom _colorRandom;

    private static int s_maxRoll = 1;

    private int _minCount = 2;
    private int _maxCount = 6;
    private int _minRoll = 1;

    public void TrySpawn(Vector3 spawnScale)
    {
        Debug.Log("шанс = " + s_maxRoll.ToString());

        if (RollChance())
        {
            int сount = Random.Range(_minCount, _maxCount + 1);

            for (int i = 0; i < сount; i++)
            {
                GameObject spawnedObject = Instantiate(_prefab, transform.position, transform.rotation);
                spawnedObject.transform.localScale = spawnScale;
                _colorRandom.ChangeColor(spawnedObject);
            }

            Debug.Log("шанс = " + s_maxRoll.ToString());
        }
    }

    private bool RollChance()
    {
        int chance = Random.Range(_minRoll, s_maxRoll + 1);

        bool isSuccess = (chance == s_maxRoll);

        s_maxRoll *= 2;

        return isSuccess;
    }
}
