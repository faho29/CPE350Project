using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;  // Speed of the ball movement
    public Transform cameraTransform;  // Reference to the camera's transform
    public float repelForce = 10f;  // Force applied when colliding with an enemy

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("HorizontalWASD");
        float moveVertical = Input.GetAxis("VerticalWASD");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;
        rb.AddForce(movement * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(repelDirection * repelForce, ForceMode.Impulse);

            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                enemyRb.AddForce(-repelDirection * repelForce, ForceMode.Impulse);
            }
        }
    }
}
