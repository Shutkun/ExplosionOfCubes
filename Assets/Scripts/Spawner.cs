using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private ColorRandom _colorRandom;

    public List<Rigidbody> CreateCubs(Vector3 spawnScale)
    {

        List<Rigidbody> childsCubs = new List<Rigidbody>();

        int minCount = 2;
        int maxCount = 6;

        int сount = Random.Range(minCount, maxCount + 1);

        for (int i = 0; i < сount; i++)
        {
            Rigidbody spawnedObject = Instantiate(_prefab, transform.position, transform.rotation);
            spawnedObject.transform.localScale = spawnScale;
            _colorRandom.ChangeColor(spawnedObject);
            childsCubs.Add(spawnedObject.GetComponent<Rigidbody>());
        }

        Debug.Log($"CreateCubs вызван. Количество создаваемых объектов: {сount}");
        return childsCubs;
    }

    public void DestroyCube(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
