using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    Rigidbody2D rb;
    Vector2 velocity;
    Vector2 direction = new Vector2(1,1);
    public static Action MissedBall = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(moveSpeed,moveSpeed);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        direction = Vector2.Reflect(direction, other.contacts[0].normal);
        rb.velocity = Vector2.Scale(direction, velocity);

        if(other.gameObject.tag == "Brick")
        {
            moveSpeed += .1f;
            velocity = Vector2.Scale(velocity.normalized, 
                new Vector2(moveSpeed,moveSpeed));
            rb.velocity = Vector2.Scale(direction, velocity);
        }
        print(velocity);
        print(direction);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        transform.position = new Vector2(0,0);
        MissedBall.Invoke();
    }
}
