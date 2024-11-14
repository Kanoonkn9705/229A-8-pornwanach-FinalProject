using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    Vector2 move;
    float moveX;
    float speed;
    float jumpForce;
    bool facingRight = true;

    void Start()
    {
        speed = 500f;
        jumpForce = 13.5f;
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(0, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (moveX > 0 && !facingRight)
            Flip();
        else if (moveX < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
