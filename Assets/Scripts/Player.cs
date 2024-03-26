using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float speed = 5.0f; // Speed of the player
    private Rigidbody rb;
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Get the Animator component attached to this GameObject
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        // Update the Speed parameter in the Animator
        animator.SetFloat("Speed", movement.magnitude);
    }

    void Die()
    {
        Debug.Log("Player has died!");
        // Implement death logic here
        FindObjectOfType<GameManager>().GameOver();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Die();
        }
    }
}
