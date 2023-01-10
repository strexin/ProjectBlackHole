using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;

    [SerializeField] private LayerMask groundLayerMask;

    private float moveInput;
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
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0)
        {
            float targetMoveSpeed = moveInput * moveSpeed;
            float speedDif = targetMoveSpeed - rb.velocity.x;
            float accelRate = (Mathf.Abs(targetMoveSpeed) > 0.01f) ? accel : decel;

            float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velocity) * Mathf.Sign(speedDif);

            rb.AddForce(movement * Vector2.right);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
    }

    private bool isGrounded()
    {
        float extraDistance = 0.15f;
        RaycastHit2D raycast = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraDistance, groundLayerMask);

        Color raycolor;
        if (raycast.collider != null)
        {
            raycolor = Color.green;
        }
        else
        {
            raycolor = Color.red;
        }

        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraDistance), raycolor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraDistance), raycolor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + extraDistance), Vector2.right * (bc.bounds.extents.x), raycolor);

        return raycast.collider != null;
    }

    private void Jump()
    {
        Vector2 jumpVelocity = new Vector2(0.0f, jumpForce);
        rb.velocity += jumpVelocity;

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = GScale * fallingGravity;
        }
        else
        {
            rb.gravityScale = GScale;
        }
    }
}
