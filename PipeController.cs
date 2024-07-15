using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the pipe moves
    public float destroyTime = 10f; // Time after which the pipe is destroyed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Start destroying the pipe after `destroyTime` seconds
        Destroy(gameObject, destroyTime);

        // Ignore collisions with objects in the "Floor" layer for all child colliders
        IgnoreFloorLayerForChildren();
    }

    void FixedUpdate()
    {
        // Move the pipe to the left using Rigidbody forces
        rb.velocity = Vector3.left * moveSpeed;
    }

    void IgnoreFloorLayerForChildren()
    {
        // Get all child colliders of the pipe
        Collider[] childColliders = GetComponentsInChildren<Collider>();

        // Ignore collisions with objects in the "Floor" layer for each child collider
        foreach (Collider childCollider in childColliders)
        {
            int floorLayer = LayerMask.NameToLayer("Floor");
            if (floorLayer != -1)
            {
                Physics.IgnoreCollision(childCollider, GameObject.FindWithTag("Floor").GetComponent<Collider>());
            }
        }
    }
}
