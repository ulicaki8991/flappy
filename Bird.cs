using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
  
    public float jumpForce = 5f; // Adjust this value to control jump height

    private Rigidbody rb;
    public GM gm;

    [Header("StartGame")]
    [SerializeField] float LimitY;
    

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


        if(!gm.GameStarted && gameObject.transform.position.y <= LimitY)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector3.up * jumpForce; // Apply upward force to jump
    }

    private void OnCollisionEnter(Collision collision)
    {
        gm.GameEnd();
    }
}
