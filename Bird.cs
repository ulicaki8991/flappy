using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
  
    public float jumpForce = 5f; // Adjust this value to control jump height

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button press
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector3.up * jumpForce; // Apply upward force to jump
    }
}
