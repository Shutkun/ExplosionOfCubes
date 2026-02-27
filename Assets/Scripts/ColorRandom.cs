using UnityEngine;

public class ColorRandom : MonoBehaviour
{
    public void ChangeColor(GameObject gameObject)
    {
        float minRoll = 0f;
        float maxRoll = 1f;

        float visibility = 1f;
        float redRange = Random.Range(minRoll, maxRoll + 1);
        float greenRange = Random.Range(minRoll, maxRoll + 1);
        float blueRange = Random.Range(minRoll, maxRoll + 1);

        Renderer objectRender = gameObject.GetComponent<Renderer>();

        objectRender.material.color = new Color(redRange, greenRange, blueRange, visibility);
    }
}
