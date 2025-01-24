using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove :MonoBehaviour {
    public float runSpeed = 4;
    public float jumpForce = 8;
    Rigidbody2D rb2d;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 0.5f;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>(); ///initialize obj when the game start
    }

    private void FixedUpdate() {
        playerMovement();
        jumpMovement();

    }
    private void playerMovement() {
        if(Input.GetKey("d") || Input.GetKey("right")) {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
        } else if(Input.GetKey("a") || Input.GetKey("left")) {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
        } else {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); ///when it's not moving
        }
    }
    private void jumpMovement() {

        if(Input.GetKey("space") && CheckGround.isGrounded) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
        //behavior
        if(betterJump) {
            if(rb2d.velocity.y < 0) {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            }
            if(rb2d.velocity.y > 0 && !Input.GetKey("space")) {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;

            }
        }


    }
}
