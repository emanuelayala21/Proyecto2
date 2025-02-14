using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove :MonoBehaviour {
    public float runSpeed = 4;
    public float jumpForce = 6;
    public float doubleJumpSpeed = 6;

    private bool canDoubleJump = false;

    Rigidbody2D rb2d;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    ///movement
    private SpriteRenderer sprite;
    private Animator animator;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>(); ///initialize obj when the game start
        sprite = rb2d.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); ///Retrieves and assigns the Animator component attached to this obj.
    }
    private void Update() {
        jumpMovement();
    }

    private void FixedUpdate() {
        playerMovement();
        groundBehavior();
    }
    private void playerMovement() {
        if(Input.GetKey("d") || Input.GetKey("right")) {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);

            sprite.flipX = false;

            animator.SetBool("Run", true);

        } else if(Input.GetKey("a") || Input.GetKey("left")) {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);

            sprite.flipX = true;

            animator.SetBool("Run", true);

        } else {

            rb2d.velocity = new Vector2(0, rb2d.velocity.y); ///when it's not moving
            animator.SetBool("Run", false);

        }
    }
    private void jumpMovement() {

        if(Input.GetKey("space")) {
            if(CheckGround.isGrounded) {//first jump
                canDoubleJump = true;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            } else {
                if(Input.GetKeyDown("space") && canDoubleJump) { ///double jump
                    animator.SetBool("DoubleJump", true);
                    rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJumpSpeed);
                    canDoubleJump = false; //double jump false
                }
            }
            //behavior
            if(rb2d.velocity.y < 0) {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            }
            if(rb2d.velocity.y > 0 && !Input.GetKey("space")) {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;

            }
        }
    }
    private void groundBehavior() {
        // Improved animation handling
        if(CheckGround.isGrounded == false) {
            animator.SetBool("Jump", true); // Activate jump animation
            animator.SetBool("Run", false); // Disable run animation when in the air
        } else {
            animator.SetBool("Jump", false); // Disable jump animation
            animator.SetBool("DoubleJump", false); // Disable double jump animation
            animator.SetBool("Falling", false); // Disable falling animation

            if(Mathf.Round(rb2d.velocity.x) != 0) { // Check horizontal movement
                animator.SetBool("Run", true); // Activate run animation if moving
            } else {
                animator.SetBool("Run", false); // Disable run animation if stationary
            }
        }
        if(rb2d.velocity.y < 0) {
            animator.SetBool("Falling", true);

        } else {
            animator.SetBool("Falling", false); // Disable falling animation

        }
    }

}

