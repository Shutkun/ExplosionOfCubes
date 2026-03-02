using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private Raycast _raycast;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    private float _scaleIndex = 0.5f;


    private void OnEnable()
    {
        _raycast.Hit += Splitting;
    }

    private void OnDisable()
    {
        _raycast.Hit -= Splitting;
    }

    private void Splitting(GameObject targetObject)
    {
        Vector3 _currentScale = transform.localScale * _scaleIndex;
        _spawner.CreateCubs(_currentScale);
        _spawner.DestroyCube(targetObject);
        _explosion.AddForce(_spawner.CreateCubs(transform.localScale));
    }
}
