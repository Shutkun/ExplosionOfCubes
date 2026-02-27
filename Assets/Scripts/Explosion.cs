using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private Spawner _spawner;

    private float _scaleIndex = 0.5f;


    private void OnMouseUpAsButton()
    {
        Vector3 _currentScale = transform.localScale * _scaleIndex;

        _spawner.TrySpawn(_currentScale);
        AddForce(_spawner.TrySpawn(_currentScale));
        Destroy(gameObject);
    }

    private void AddForce(List<Rigidbody> childCubs)
    {
        foreach (Rigidbody explodableObject in childCubs)
        {
            explodableObject.AddExplosionForce(_force, transform.position, _radius);
        }
    }
}
