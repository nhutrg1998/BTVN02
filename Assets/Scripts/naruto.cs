using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naruto : MonoBehaviour
{
    Vector2 pos;
    float jumpPow = 220f;
    int numJump = 0;
    bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        GetComponent<Animator>().SetBool("grounded", grounded);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) 
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x -= 0.3f;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                pos.x += 0.3f;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            transform.position = pos;
            if (grounded)
                GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
            GetComponent<Animator>().SetBool("isRunning", false);

        if (Input.GetKeyDown(KeyCode.UpArrow) && numJump < 2)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPow);
            grounded = false;
            numJump++;
        }
        
        if (!grounded)
        {
            GetComponent<Animator>().SetBool("isJumping", true);
        }
        else GetComponent<Animator>().SetBool("isJumping", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        numJump = 0;
    }
}
