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

    private void Splitting(Rigidbody targetObject)
    {
        Debug.Log("Запуск инициализатора");

        Vector3 _currentScale = transform.localScale * _scaleIndex;

        _spawner.CreateCubs(_currentScale, targetObject.transform.position);
        _explosion.AddForce(_spawner.GetListChildsCubs());
        _spawner.DestroyCube(targetObject);
    }
}
