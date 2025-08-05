using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    [SerializeField] private Color _color;
    void Start()
    {
        // Get the Renderer component of the cube
        Renderer cubeRenderer = GetComponent<Renderer>();

        // Change its color to red
        cubeRenderer.material.color = _color;

        // Or use a custom color
        // cubeRenderer.material.color = new Color(0.5f, 1f, 0.2f); // RGB values (0–1)
    }
}
