using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D cd;

    private float verticalInput;
    private float horizontalInput;

    private bool isMoving;
    private bool isAlive;

    [SerializeField] private float moveSpeed;

    private float GScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        GScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (verticalInput != 0.0f || horizontalInput != 0)
        {
            isMoving = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (horizontalInput != 0 && isMoving)
        {
            rb.AddForce(Vector2.right * horizontalInput * moveSpeed);
        }

        if (verticalInput != 0 && isMoving)
        {
            rb.AddForce(Vector2.up * verticalInput * moveSpeed);
        }
        
    }

    private void Die()
    {
        isAlive = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
            Die();
        }      
    }
}
