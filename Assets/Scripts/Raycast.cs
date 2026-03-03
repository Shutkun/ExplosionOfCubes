using System;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public event Action<Rigidbody> Hit;
    private Rigidbody clickedObject;

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
        Debug.Log("Запуск рейкаста");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            BoxCollider collider = hit.transform.GetComponent<BoxCollider>();

            if (collider != null)
            {
                clickedObject = hit.rigidbody;
                OnPlayerClick();
            }
        }
    }

    private void OnPlayerClick()
    {
        Hit?.Invoke(clickedObject);
    }
}
