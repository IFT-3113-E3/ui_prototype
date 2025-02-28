using UnityEngine;
using UnityEngine.UI;

public class MapCursor : MonoBehaviour
{
    public RectTransform mapRect; // Référence au RectTransform de la carte
    public RectTransform cursor; // Référence au RectTransform du curseur

    private void Update()
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            mapRect, Input.mousePosition, null, out Vector2 localPoint))
        {
            // Déplacer le curseur
            cursor.anchoredPosition = localPoint;
        }
    }
}