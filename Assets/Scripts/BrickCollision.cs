using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    [SerializeField, Range(1, 15)] int brickScore;
    public static Action<int> BrickWasDestroyed = delegate { };

    private void OnCollisionEnter2D(Collision2D other) {
        BrickWasDestroyed.Invoke(brickScore);
        Destroy(gameObject);
    }
}
