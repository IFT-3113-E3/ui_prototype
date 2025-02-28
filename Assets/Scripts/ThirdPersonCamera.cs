using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // La cible que la caméra doit suivre (ton personnage)
    public Vector3 offset = new Vector3(0f, 2f, -4f); // Décalage de la caméra par rapport au personnage
    public float smoothSpeed = 0.125f; // Lissage des mouvements de la caméra

    void Start()
    {
        // Déverrouille le curseur de la souris pour pouvoir interagir avec l'UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calcul de la position désirée de la caméra
        Vector3 desiredPosition = target.position + offset;

        // Lissage du mouvement de la caméra
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Oriente la caméra vers le personnage
        transform.LookAt(target);
    }
}