using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    Rigidbody2D rb;
    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(moveSpeed,moveSpeed);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        velocity = Vector2.Reflect(velocity, other.contacts[0].normal);
        rb.velocity = velocity;
        print(rb.velocity);

        // print(other.contacts[0].normal.y);
        // if((int) other.contacts[0].normal.x != 0)
        // {
        //     velocity.x *= -1;
        // }
        // if((int) other.contacts[0].normal.y != 0)
        // {
        //     velocity.y *= -1;
        // }
        // print(velocity);
        // rb.velocity = velocity;
        if(other.gameObject.tag == "Brick")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        transform.position = new Vector2(0,0);
    }
}
