using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        print("Destroy");
        Destroy(gameObject);
    }
}
