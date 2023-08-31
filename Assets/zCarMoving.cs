using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zCarMoving : MonoBehaviour
{
    public float moveSpeed = 10f; // Adjust the speed in the Inspector
    public float rotationSpeed = 45f; // Adjust the rotation speed in the Inspector

    private Rigidbody2D rb;

    public int heartsCollected = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on car's forward direction
        Vector2 movement = rb.transform.up * moveSpeed * Time.deltaTime;

        if (verticalInput < 0)
        {
            // Move the car backward
            rb.MovePosition(rb.position - movement);
        }
        else
        {
            // Move the car forward
            rb.MovePosition(rb.position + movement);
        }

        if (horizontalInput < 0)
        {
            // Rotate the car left
            rb.rotation += rotationSpeed * Time.deltaTime;
        }
        else if (horizontalInput > 0)
        {
            // Rotate the car right
            rb.rotation -= rotationSpeed * Time.deltaTime;
        }


    }

    private void OnTriggerEnter2D(Collider2D heartObject)
    {
        if (heartObject.CompareTag("Heart"))
        {
            // Collect the heart
            Destroy(heartObject.gameObject);
            heartsCollected++;
            Debug.Log("Heart collected!");
        }
    }
}
