using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private ColorRandom _colorRandom;
    [SerializeField] private float _spawnProbability;


    public List<Rigidbody> CreateCubs(Vector3 spawnScale, Vector3 position)
    {
        List<Rigidbody> _childsCubs = new List<Rigidbody>();

        if (IsSplitting())
        {
            int minCount = 2;
            int maxCount = 6;
            int сount = Random.Range(minCount, maxCount + 1);

            for (int i = 0; i < сount; i++)
            {
                Rigidbody spawnedObject = Instantiate(_prefab, position, transform.rotation);
                spawnedObject.transform.localScale = spawnScale;

                _colorRandom.ChangeColor(spawnedObject);

                _childsCubs.Add(spawnedObject);

            }
        }

        return _childsCubs;
    }

    public void DestroyCube(Rigidbody gameObject)
    {
        Destroy(gameObject.transform.gameObject);
    }

    private bool IsSplitting()
    {
        if (Random.value < _spawnProbability)
        {
            _spawnProbability /= 2;

            return true;
        }

        return false;
    }
}
