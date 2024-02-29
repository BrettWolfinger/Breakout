using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for triggering the paddle to shrink when top wall is hit
public class TopWallCollision : MonoBehaviour
{
    public static Action TopWallHit = delegate { };

    private void OnCollisionEnter2D(Collision2D other) {
        TopWallHit.Invoke();
    }
}

