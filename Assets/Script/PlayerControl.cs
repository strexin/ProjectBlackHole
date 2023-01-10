using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;

    [SerializeField] private LayerMask groundLayerMask;

    private float verticalInput;
    private float horizontalInput;

    private bool isMoving;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float accel;
    [SerializeField] private float decel;
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallingGravity;

    private float GScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
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
}
