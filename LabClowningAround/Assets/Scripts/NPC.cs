using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
public class NPC : MonoBehaviour
{
    /* Properties */
    [Header("Movement")]
    public float moveSpeed = 1;
    public bool canMove = false;
    public bool moveRightAtStart = true;
    public float turnCooldown = 1; // In seconds

    [Header("Physics")]
    public float acceleration = 1;

    /* References */
    private Rigidbody2D rb;

    /* State */
    private bool isMovingRight = true;
    private float lastTurnTime = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        isMovingRight = moveRightAtStart;
    }

    private void Update()
    {
        if (!canMove)
            return;

        CheckTurn();        // See if NPC needs to turn
        ApplyVelocity();    // Ensure RB velocity is what it needs to be
    }

    private void CheckTurn()
    {
        if (Time.time - lastTurnTime < turnCooldown)
            return;

        // If the velocity of the NPC has dropped beneath a threshold, it cannot move anymore and must turn
        if (rb.velocity.sqrMagnitude < 0.0001)
        {
            isMovingRight = !isMovingRight;
            lastTurnTime = Time.time;
        }
    }

    private void ApplyVelocity()
    {
        float desiredVelocity = isMovingRight ? moveSpeed : -moveSpeed;
        float velocityDifference = desiredVelocity - rb.velocity.x;

        velocityDifference *= acceleration;

        rb.AddForce(new Vector2(velocityDifference, 0), ForceMode2D.Force);
    }


    private void OnDrawGizmos()
    {
        if (!canMove)
            return;

        Gizmos.color = Color.yellow;
        Vector3 direction = (moveRightAtStart ? Vector3.right : Vector3.left);
        direction *= moveSpeed;
        Gizmos.DrawLine(transform.position, transform.position + direction);
    }
}
