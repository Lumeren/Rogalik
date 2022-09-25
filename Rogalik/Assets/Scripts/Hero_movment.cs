using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_movment : MonoBehaviour
{
    public Vector2 moveVector;
    public float speed = 2f;
    public Animator anim;
    public SpriteRenderer sr;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
        Reflect();
        Jump();
        CheckingGround();
        Lungh();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    public bool faceRight = true;

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    public float jumpForse = 7f;

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround )
        {
            rb.AddForce(Vector2.up * jumpForse);
        }
    }

    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);

        anim.SetBool("onGround", onGround);
    }

    public int lungeImpulse;
    void Lungh()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !lockLinge)
        {
            lockLinge = true;
            Invoke("lockLunghe", 2f);

            anim.StopPlayback();
            anim.Play("lunge");

            rb.velocity = new Vector2(0, 0);

            if (!faceRight) { rb.AddForce(Vector2.left * lungeImpulse); }
            else { rb.AddForce(Vector2.right * lungeImpulse);  }
        }
    }


    private bool lockLinge = false;

    void lockLunghe()
    {
        lockLinge = false;
    }


}
