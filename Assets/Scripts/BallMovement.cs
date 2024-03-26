using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

//Put on the ball prefab to control ball movement
public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float moveSpeedIncrease = .1f;
    [SerializeField] float verticalPushThreshold = .75f;
    [SerializeField] float verticalPushMultiplier = 1.25f;

    Rigidbody2D rb;
    Vector2 direction = new Vector2();
    public static Action MissedBall = delegate { };
    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GenerateStartingDirection();
        rb.velocity = direction * moveSpeed;
    }

    /*Used when the ball's trajectory gets too flat
    (y component gets small) to give the ball an adjustment so
    it doesn't get stuck
    */
    void ApplyVerticalPush()
    {
        direction = Vector2.Scale(direction, 
                new Vector2(1f,verticalPushMultiplier));
        rb.velocity = direction * moveSpeed;
    }

    //generate a starting direction between the 45 deg diagonals going towards the paddle
    void GenerateStartingDirection()
    {
        direction.x = UnityEngine.Random.Range(-1f,1f);
        direction.y = -1;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        //Change balls direction
        direction = Vector2.Reflect(direction, other.contacts[0].normal);

        //Increase movespeed each time a brick gets destroyed
        if(other.gameObject.tag == "Brick")
        {
            moveSpeed += moveSpeedIncrease;
        }

        rb.velocity = direction * moveSpeed;

        //if the ball's trajectory gets too flat give it a shove to the vertical
        if(Math.Abs(direction.y) < verticalPushThreshold)
        {
            ApplyVerticalPush();
        }
    }

    //Trigger placed below viewable screen to restart the game on a missed ball
    private void OnTriggerEnter2D(Collider2D other) {
        transform.position = new Vector2(0,0);
        GenerateStartingDirection();
        rb.velocity = direction * moveSpeed;
        MissedBall.Invoke();
    }
}
