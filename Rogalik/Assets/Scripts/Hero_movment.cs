using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_movment : MonoBehaviour
{
    public float  speed = 1f;
    public float jampForse = 5f;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movment = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movment, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
            rb.AddForce(new Vector2(0, jampForse), ForceMode2D.Impulse);

        sr.flipX = movment < 0 ? true : false;
    }
}
