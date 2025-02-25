using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpDamage :MonoBehaviour {

    public Collider2D col2d; 
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyParticle;
    public float jumpForce = 2.5f;
    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            hitByPlayer();
            checkLife();


        }
    }
    public void hitByPlayer() {
        lifes--;
        animator.Play("chickenhit");
    }
    public void checkLife() {
        if(lifes == 0) {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("enemyDie", 0.5f);
        }
    }

    void enemyDie () {
        Destroy(this.gameObject);
    }
}
