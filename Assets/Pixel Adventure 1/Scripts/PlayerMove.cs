using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2; /// velocidad
    public float jumpSpped = 3; ///fuerza hacia arriba
    Rigidbody2D rb2d; 
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    

    private void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(- runSpeed, rb2d.velocity.y);
        }
    }
}
