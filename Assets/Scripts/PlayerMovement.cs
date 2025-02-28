using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement
    public float gravity = 9.81f; // Force de la gravité
    public float rotationSpeed = 10f; // Vitesse de rotation

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Initialise le mouvement à zéro
        Vector3 move = Vector3.zero;

        // Détecte les touches des flèches directionnelles
        if (Input.GetKey(KeyCode.UpArrow)) // Flèche vers le haut
        {
            move += transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Flèche vers le bas
        {
            move -= transform.forward;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Flèche vers la droite
        {
            move += transform.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // Flèche vers la gauche
        {
            move -= transform.right;
        }

        // Normalise le mouvement pour éviter une vitesse accrue en diagonale
        move = move.normalized;

        // Applique le mouvement
        controller.Move(move * speed * Time.deltaTime);

        // Appliquer la gravité
        if (!controller.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            velocity.y = -2f; // Empêche d'accumuler de la vitesse en tombant
        }

        // Fait tourner le personnage pour qu'il regarde dans la direction du mouvement
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}