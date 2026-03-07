using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void AddForce(List<Rigidbody> childCubs, Rigidbody targetObject)
    {
        foreach (Rigidbody explodableObject in childCubs)
        {
            explodableObject.AddExplosionForce(_force, targetObject.gameObject.transform.position, _radius);
        }
    }
}
