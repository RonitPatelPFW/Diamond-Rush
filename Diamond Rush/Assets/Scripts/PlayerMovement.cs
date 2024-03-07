using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private Rigidbody2D rb;

    public bool ClimbingAllowed { get; set; }
	float climbSpeed;
    public float runSpeed = 40f;

    private float horizontalMove;
    private bool jump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            if (ClimbingAllowed)
            {
                animator.SetBool("climbing", true);
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("climbing", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

        if (ClimbingAllowed)
        {
            climbSpeed = Input.GetAxisRaw("Vertical") * 5f;
            rb.isKinematic = true;
			rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontalMove, climbSpeed);
        }
        else
        {
            rb.isKinematic = false;
			rb.gravityScale = 4f;
            rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        }
    }
}
