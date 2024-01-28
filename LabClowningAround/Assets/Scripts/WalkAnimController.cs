using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class WalkAnimController : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public bool speedByVelocity = true;
    public string velocityParam = "WalkSpeed";
    public bool directionControl = true;
    public bool defaultDirectionRight = true;    

    public SpriteRenderer mainSprite;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        mainSprite.flipX = defaultDirectionRight ? 
            rb.velocity.x < 0 :
            rb.velocity.x > 0;


        float walkSpeed = Mathf.Abs(rb.velocity.x) / maxSpeed;
        walkSpeed = Mathf.Clamp01(walkSpeed);

        animator.SetFloat(velocityParam, walkSpeed*1.5f);
    }

}
