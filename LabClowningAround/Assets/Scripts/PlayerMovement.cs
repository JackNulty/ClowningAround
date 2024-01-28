using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.ParticleSystemJobs;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10;
    public float acceleration = 1.0f;
    public float deceleration = 1.0f;
    public float groundDistance = 0.1f;
    
    private InputAction moveInput;
    private InputAction jumpInput;
    public Rigidbody2D rb;

    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        PlayerInput inputSystem = GetComponent<PlayerInput>();
        moveInput = inputSystem.actions.FindAction("Move");
        jumpInput = inputSystem.actions.FindAction("Jump");

        moveInput.performed += OnMoveUpdated;
        jumpInput.performed += OnJumpPerformed;
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        float desiredVelocity = moveSpeed * moveDirection.x;
        float differenceVelocity = desiredVelocity - rb.velocity.x;

        // If horizontal input is 0 decelerate instead of accelerate
        // floats are bad at == 0 so we check if it's below minimum threshold (epsilon)
        float scale = Mathf.Abs(moveDirection.x) < float.Epsilon ? deceleration : acceleration;
        

        rb.AddForce(differenceVelocity * scale * Vector2.right, ForceMode2D.Force);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the move input event
        moveInput.performed -= OnMoveUpdated;
        moveInput.canceled -= OnMoveUpdated;
        jumpInput.performed -= OnJumpPerformed;
    }
    private void OnMoveUpdated(InputAction.CallbackContext context)
    {
        // Read the move input
        moveDirection = context.ReadValue<Vector3>();
    }
    

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (!CanJump()) 
            return;
        
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Checks if the player is raising/falling and that there's floor beneath them
    private bool CanJump() =>
        rb.velocity.y < 0.01f &&
        Physics2D.Raycast(transform.position, Vector2.down, groundDistance);


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.down * groundDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pickup")
        {
            Debug.Log("Laughing pickup activated");
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Balloon")
        {
            //Instantiate(ballonPop,collision.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
