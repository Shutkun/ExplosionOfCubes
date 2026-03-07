using UnityEngine;

public class Separator : MonoBehaviour
{
    [SerializeField] private Raycast _raycast;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _detonator;

    private float _scaleIndex = 0.5f;

    private void OnEnable()
    {
        _raycast.Hit += Splitting;
    }

    private void OnDisable()
    {
        _raycast.Hit -= Splitting;
    }

    private void Splitting(Rigidbody targetObject)
    {
        Vector3 _currentScale = targetObject.transform.localScale * _scaleIndex;

        _detonator.AddForce(_spawner.CreateCubs(_currentScale, targetObject.transform.position), targetObject);
        _spawner.DestroyCube(targetObject);
    }
}
