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
        AddForce();
        Destroy(gameObject);
    }

    private void AddForce()
    {
        foreach (Rigidbody explodableObject in GetObjects())
        {
            explodableObject.AddExplosionForce(_force, transform.position, _radius);
        }
    }

    private List<Rigidbody> GetObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> cubs = new();

        foreach (Collider hit in hits)
        {
            if (hit.GetComponent<Rigidbody>() != null)
            {
                cubs.Add(hit.attachedRigidbody);
            }
        }

        return cubs;
    }
}
