using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void AddForce(List<Rigidbody> childCubs)
    {
        foreach (Rigidbody explodableObject in childCubs)
        {
            explodableObject.AddExplosionForce(_force, transform.position, _radius);
        }
    }

    public void Destroy(GameObject cube)
    {
        Destroy(cube.gameObject);
    }
}
