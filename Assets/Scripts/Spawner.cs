using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private ColorRandom _colorRandom;

    private List<Rigidbody> _childsCubs = new List<Rigidbody>();

    public void CreateCubs(Vector3 spawnScale, Vector3 position)
    {
        Debug.Log("Запуск спавнера");
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
        Debug.Log("После цикла спавнера " + _childsCubs.Count.ToString());
    }

    public void DestroyCube(Rigidbody gameObject)
    {
        Destroy(gameObject.transform.gameObject);
        Debug.Log("После уничтожения объекта " + _childsCubs.Count.ToString());
        _childsCubs.Clear();
        Debug.Log("После зачистки листа дочерних объектов " + _childsCubs.Count.ToString());
    }

    public List<Rigidbody> GetListChildsCubs() => _childsCubs.ToList();
}
