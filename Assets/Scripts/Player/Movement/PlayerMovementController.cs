using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // The amount it will move every second
    [SerializeField]
    private float horizontalSpeedForce = 8f;
    [SerializeField]
    private float maxHorizontalSpeed = 30f;
    [SerializeField]
    private float maxVerticalSpeed = 20f;
    [SerializeField]
    private float horizontalForceDegredation = 0.90f;
    [SerializeField]
    private float jumpForce = 400f;
    [SerializeField]
    private int maxJumps = 2;

    private int jumps = 0;

    private Rigidbody2D rb;

    public int getMaxJumps() { return maxJumps; }
    public void setJumps(int j) { jumps = j; }
    
    private void Start()
    {
        // Get the RigidBody attached to the component
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Moving forces
        //Vector3 forceToAdd = Vector3.right * horizontalSpeedForce * Input.GetAxis("Horizontal");
        //rb.AddForce(forceToAdd, ForceMode2D.Force);

        // Using tranform.Translate because that is known to work
        // 
        // Note: This will cause weird issues with the camera so it is important that we account for this and maybe make this smarter
        transform.Translate(Vector3.right * horizontalSpeedForce * Input.GetAxis("Horizontal") * Time.deltaTime);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && jumps != 0)
        {
            // Cancel all momentum
            rb.velocity = rb.velocity.x * Vector3.right;
            rb.AddForce(jumpForce * Vector3.up);
            jumps--;
        }
    }

    void FixedUpdate()
    {
        // Clamping forces and slow them down horizontally
        //
        // Degredation should only happen when the player is not moving
        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed) * (Input.GetAxis("Horizontal") == 0 ? horizontalForceDegredation : 1),
            Mathf.Clamp(rb.velocity.y, -maxVerticalSpeed, maxHorizontalSpeed)
        );
    }
}
