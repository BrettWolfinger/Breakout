using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put on brick prefab to handle collision events
public class BrickCollision : MonoBehaviour
{
    [SerializeField, Range(1, 15)] int brickScore;
    public static Action<int> BrickWasDestroyed = delegate { };

    //broadcast brick destroy event along with score of associated brick
    private void OnCollisionEnter2D(Collision2D other) {
        BrickWasDestroyed.Invoke(brickScore);
        Destroy(gameObject);
    }
}
