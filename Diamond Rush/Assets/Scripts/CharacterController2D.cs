using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                            // Amount of force added when the player jumps.
    [SerializeField] private bool m_AirControl = false;                           // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                            // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                             // A position marking where to check if the player is grounded.

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Rigidbody2D m_Rigidbody2D;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        Collider2D[] colliders = Physics2D.OverlapAreaAll(m_GroundCheck.position - Vector3.one * k_GroundedRadius, m_GroundCheck.position + Vector3.one * k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool jump)
    {
        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // Move the character by finding the target velocity
            Vector2 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then apply it to the character
            m_Rigidbody2D.velocity = targetVelocity;

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && transform.localScale.x < 0)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && transform.localScale.x > 0)
            {
                // ... flip the player.
                Flip();
            }

            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
