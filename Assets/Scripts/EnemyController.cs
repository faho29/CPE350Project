using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float moveSpeed = 5f;  // Speed at which the enemy moves towards the player

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("Player").GetComponent<Transform>();

        // Ensure the player reference is set
        if (player == null)
        {
            Debug.LogError("Player not assigned to the enemy!");
        }
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();

        if (transform.position.y < -10) 
        {
            Destroy(gameObject);
        }
    }

    void MoveTowardsPlayer()
    {
        if (player == null) return;

        // Calculate direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Apply force to move the enemy constantly towards the player
        rb.AddForce(direction * moveSpeed, ForceMode.Force);
    }
}
