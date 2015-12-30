using UnityEngine;
using UnityEngine.UI;

public class RisingText : MonoBehaviour
{
    private Vector3 speedVector;
    private float currentAlpha;
    private float fadeDuration;

    RisingText()
    {
        currentAlpha = 1f;
        speedVector = new Vector3(0f, 1f, 0f);
        fadeDuration = 0.5f;
    }

    public void Setup(string text, float duration, float upSpeed)
    {
        GetComponent<Text>().text = text;
        fadeDuration = 1f / duration;
        speedVector = new Vector3(0f, upSpeed, 0f);
    }

    void Update() 
    {
        // Move upwards
        transform.Translate(speedVector * Time.deltaTime, Space.World);

        // Change alpha
        currentAlpha -= Time.deltaTime * fadeDuration;
        Color color = GetComponent<Text>().color;
        color.a = currentAlpha;
        GetComponent<Text>().color = color;

        // If completely faded out, die
        if (currentAlpha <= 0f) Destroy(gameObject);
    }
}
