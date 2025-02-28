using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline :MonoBehaviour {

    private Animator animator;
    private float jumpForce = 8f;

    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            animator.Play("jump");
        }
    }

}
