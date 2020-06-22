using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.fixedDeltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (rb.velocity.y <= 0)
        {
            rb.gravityScale = 2;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
