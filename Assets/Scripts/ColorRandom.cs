using UnityEngine;

public class ColorRandom : MonoBehaviour
{
    public void ChangeColor(Rigidbody gameObject)
    {
        Debug.Log("Запуск замены цвета");

        Renderer objectRender = gameObject.GetComponent<Renderer>();

        if (objectRender != null)
        {
            objectRender.material.color = Random.ColorHSV();
        }
    }
}
