using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public string tagMask;
    public Transform target;
    public float radius;
    [Range(0,360)]
    public float outputAngle;

    public float addedForce = 2.0f;

    private void Awake()
    {
        CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius = radius;
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (target == null)
        {
            Debug.LogError("[Teleporter] No target assigned!");
            return;
        }

        Rigidbody2D otherRB = other.attachedRigidbody;

        if (otherRB.gameObject.CompareTag(tagMask))
        {
            Vector2 outputHeading = Quaternion.Euler(0, 0, outputAngle) * Vector2.right;
            outputHeading *= otherRB.velocity.magnitude * addedForce;
            otherRB.velocity = outputHeading;
            otherRB.MovePosition(target.position);
        }
    }

    private void OnDrawGizmos()
    {
        if (target == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawLine(transform.position, target.position);
        Gizmos.DrawWireSphere(target.position, radius/2);

        Gizmos.color = Color.cyan;
        Vector2 outputHeading = Quaternion.Euler(0, 0, outputAngle) * Vector2.right;
        Gizmos.DrawRay(target.position, outputHeading * 5);
    }
}
