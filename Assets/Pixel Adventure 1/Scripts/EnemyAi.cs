using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi :MonoBehaviour {

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float speed = 2f;

    private float waitTime;
    public float startWaitTime = 0.7f;

    private int i = 0; // Index for moving between spots

    public Transform[] moveSpot;
    private Vector2 previousPos; // To store the previous position

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        waitTime = startWaitTime;
        previousPos = transform.position; // Initialize previous position
    }

    void Update() {
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[i].transform.position, speed * Time.deltaTime);  // Move the enemy towards the current target spot

        // Flip the sprite depending on the movement direction
        if(transform.position.x > previousPos.x) {
            spriteRenderer.flipX = true; // Moving right
        } else if(transform.position.x < previousPos.x) {
            spriteRenderer.flipX = false; // Moving left
        }

        previousPos = transform.position;// Store the current position as the previous position for the next frame

        if(Vector2.Distance(transform.position, moveSpot[i].transform.position) < 0.1f) { // Check if the enemy reached the current target spot
            // Wait before moving to the next spot
            if(waitTime <= 0) {// Move to the next spot or loop back to the first one
                if(i < moveSpot.Length - 1) {
                    i++;
                } else {
                    i = 0;
                }
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;

            }
        }
    }
}