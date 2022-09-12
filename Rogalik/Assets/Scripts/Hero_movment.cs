using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_movment : MonoBehaviour
{
    public Vector2 moveVector;
    public float speed = 2f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

}
