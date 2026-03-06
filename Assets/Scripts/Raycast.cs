using System;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public event Action<Rigidbody> Hit;

    private Rigidbody _clickedObject;

    private void OnEnable()
    {
        _playerInput.Clicked += CastRay;
    }

    private void OnDisable()
    {
        _playerInput.Clicked -= CastRay;
    }

    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            BoxCollider collider = hit.transform.GetComponent<BoxCollider>();

            if (collider != null)
            {
                _clickedObject = hit.rigidbody;
                OnPlayerClick();
            }
        }
    }

    private void OnPlayerClick()
    {
        Hit?.Invoke(_clickedObject);
    }
}
