using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private ColorRandom _colorRandom;
    [SerializeField] private float _spawnProbability;

    private List<Rigidbody> _childsCubs = new List<Rigidbody>();

    public void CreateCubs(Vector3 spawnScale, Vector3 position)
    {
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
    }

    public void DestroyCube(Rigidbody gameObject)
    {
        Destroy(gameObject.transform.gameObject);
        _childsCubs.Clear();
    }

    public List<Rigidbody> GetListChildsCubs() => _childsCubs.ToList();

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
