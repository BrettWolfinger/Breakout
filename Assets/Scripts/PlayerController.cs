using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    float rawInput;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x + rawInput*moveSpeed*Time.deltaTime;
        newPos.y = transform.position.y;
        rb.MovePosition(newPos);
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<float>();
    }
}
