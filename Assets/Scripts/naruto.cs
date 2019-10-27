using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naruto : MonoBehaviour
{
    float jumpPow = 220f, speed = 200f, maxSpeed = 8;
    int numJump = 0;
    bool grounded = true;

    int curHealth;
    int maxHealth = 5;

    Rigidbody2D rb2;
    Animator animator;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        GetComponent<Animator>().SetBool("grounded", grounded);
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && numJump < 2)
        {
            rb2.AddForce(Vector2.up * jumpPow);
            grounded = false;
            numJump++;
        }

        animator.SetBool("isJumping", !grounded);

        if (!grounded) animator.SetBool("isRunning", false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb2.AddForce(Vector2.left * speed);
                sr.flipX = true;
                if (rb2.velocity.x < -maxSpeed)
                    rb2.velocity = new Vector2(-maxSpeed, rb2.velocity.y);
            }
            else
            {
                rb2.AddForce(Vector2.right * speed);
                sr.flipX = false;
                if (rb2.velocity.x > maxSpeed)
                    rb2.velocity = new Vector2(maxSpeed, rb2.velocity.y);
            }
            if (grounded)
                animator.SetBool("isRunning", true);
        }
        else
            animator.SetBool("isRunning", false);

        rb2.velocity = new Vector2(rb2.velocity.x * 0.5f, rb2.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        numJump = 0;
    }
}
