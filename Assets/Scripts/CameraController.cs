using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // The object that camera will follow
    public float rotationSpeed = 100f;  // Speed of camera rotation
    public float distance = 10f;  // Distance from the target
    public float height = 5f;  // Height of the camera from the target

    private float currentRotationAngle = 0f;  // To store the current rotation angle

    void Start()
    {
        UpdateCameraPosition();
    }

    void Update()
    {
        RotateCamera();
        UpdateCameraPosition();
    }

    void RotateCamera()
    {
        // Rotate camera left/right using arrow keys
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentRotationAngle -= rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentRotationAngle += rotationSpeed * Time.deltaTime;
        }
    }

    void UpdateCameraPosition()
    {
        // Calculate the new camera position based on rotation angle
        Quaternion rotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);

        // Set the camera position and make it look at the target
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
