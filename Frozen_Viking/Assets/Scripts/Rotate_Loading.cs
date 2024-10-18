using UnityEngine;

public class Rotate_Loading : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    private RectTransform rectTransform;

    void Start()
    {
        // Get the RectTransform component from the GameObject
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Rotate the image around its Z-axis
        rectTransform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}