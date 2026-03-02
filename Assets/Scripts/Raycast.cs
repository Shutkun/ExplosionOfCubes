using System;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public event Action<GameObject> Hit;

    private GameObject clickedObject;

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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            clickedObject = hit.transform.gameObject;
            OnPlayerClick();
        }
    }

    private void OnPlayerClick()
    {
        Hit?.Invoke(clickedObject);
    }
}
