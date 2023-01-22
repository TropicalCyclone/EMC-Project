using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOpossum : MonoBehaviour
{
    public float MovementSpeed;
    public int Health;
    bool direction;

    Rigidbody2D rb;
    SpriteRenderer sr;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        if (direction)
        {
            rb.velocity = new Vector2(MovementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-MovementSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) { 
    if(collision.gameObject.tag.Equals("Platform"))
        {
            direction = !direction;
           if (direction)
            {
                sr.flipX = true;
            }
            else {
                sr.flipX = false;
            }
        }
    }
}
