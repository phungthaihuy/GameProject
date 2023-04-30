using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Animator ani;
    SpriteRenderer sr;
    Rigidbody2D rb;
    BoxCollider2D box;


    private float dirX;
    [SerializeField]private bool doubleJump;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private AudioSource jump;

    private enum movementState {idle, running, jumping, falling, doubleJump };

    // Start is called before the first frame update
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jump.Play();
                doubleJump = !doubleJump;
            }

        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        movementState state;
        if (dirX > 0f)
        {
            sr.flipX = false;
            state = movementState.running;
        }
        else if (dirX < 0f)
        {
            sr.flipX = true;
            state = movementState.running;
        }
        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = movementState.jumping;
             if (ani.GetBool("doubleJump") == false)
            {

                if (Input.GetButtonDown("Jump"))
                {
                    state = movementState.doubleJump;
                }
            }
        }
        


        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
            
        }

        ani.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, layer);
    }
}
