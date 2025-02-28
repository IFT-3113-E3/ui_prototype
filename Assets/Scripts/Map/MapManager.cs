using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject minimapCanvas; // Canvas de la minimap
    public GameObject fullMapCanvas; // Canvas de la carte complète
    public KeyCode toggleKey = KeyCode.M; // Touche pour basculer

    private bool isFullMapActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isFullMapActive = !isFullMapActive;
            minimapCanvas.SetActive(!isFullMapActive);
            fullMapCanvas.SetActive(isFullMapActive);
        }
    }
}