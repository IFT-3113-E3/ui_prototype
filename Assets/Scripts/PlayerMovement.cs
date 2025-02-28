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
        // Récupère les inputs du joueur
        float moveX = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float moveZ = Input.GetAxis("Vertical");   // W/S ou Z/S

        // Calcule le mouvement
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
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