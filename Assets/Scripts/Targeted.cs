using UnityEngine;

public class Targeted : MonoBehaviour
{
    private Renderer renderer;
    Color originalColor;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor  = renderer.material.color;

    }

    private void OnMouseEnter()
    {
        renderer.material.color = Color.blue;
    }

    private void OnMouseExit()
    {
        renderer.material.color = originalColor;
    }

}