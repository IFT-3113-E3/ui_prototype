using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float mouseSensitivity = 100f;
    public float smoothSpeed = 0.125f;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private Vector3 offset;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Mouvement de la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -30f, 70f);

        // Zoom avec la molette
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * 5f;
        distance = Mathf.Clamp(distance, 2f, 10f);

        // Calcul de la position et de la rotation
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        Vector3 desiredPosition = target.position + rotation * new Vector3(0, height, -distance);

        // Lissage de la position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.LookAt(target);
    }
}