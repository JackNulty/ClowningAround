using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.ParticleSystemJobs;

public class PlayerMovement : MonoBehaviour
{

    //Input variables 
    private InputAction moveInput;
    private InputAction fireInput;
    private InputAction jumpInput;
    [SerializeField] private float moveSpeed = 10f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lookDirection = Vector3.forward;
    private float jumping = 0;
    public Rigidbody2D rb;
    private bool isJumping = false;
    public ParticleSystem ballonPop;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Use the moveDirection to move
        Vector3 movement = new Vector3(moveDirection.x, 0f, moveDirection.z);
        movement *= moveSpeed * Time.deltaTime;

        transform.Translate(movement, Space.World);

        //lock player rotation
        transform.rotation = Quaternion.identity;

    }

    private void OnEnable()
    {
        moveInput = GetComponent<PlayerInput>().actions.FindAction("Move");
        fireInput = GetComponent<PlayerInput>().actions.FindAction("Fire");
        jumpInput = GetComponent<PlayerInput>().actions.FindAction("Jump");

        // Subscribe to the move input event
        moveInput.performed += OnMovePerformed;
        moveInput.canceled += OnMoveCanceled;

        jumpInput.performed += OnJumpPerformed;

    }

    private void OnDisable()
    {
        // Unsubscribe from the move input event
        moveInput.performed -= OnMovePerformed;
        moveInput.canceled -= OnMoveCanceled;
    }
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        // Read the move input
        moveDirection = context.ReadValue<Vector3>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Reset the move input when it's canceled
        moveDirection = Vector3.zero;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if(!isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0f, context.ReadValue<float>()), ForceMode2D.Impulse);
            //StartCoroutine(ResestJump());
        }
    }

    private IEnumerator ResestJump()
    {
        yield return new WaitForSeconds(2f);
        isJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isJumping)
        {
            if(collision.collider.tag =="Ground" )
            {
                isJumping = false;
            }

        }
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
            Instantiate(ballonPop,collision.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
