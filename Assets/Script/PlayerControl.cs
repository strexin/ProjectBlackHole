using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D cd;

    private float verticalInput;
    private float horizontalInput;

    private bool isMoving;
    public bool isAlive;

    [SerializeField] private AudioSource jetSFXSource;
    [SerializeField] private AudioSource deadSFXSource;

    [SerializeField] private AudioClip jetSFX;
    [SerializeField] private AudioClip deadSFX;

    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject playerGFX;

    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        playerAnim = playerGFX.GetComponent<Animator>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if ((verticalInput != 0.0f || horizontalInput != 0) && (isAlive))
        {
            jetSFXSource.clip = jetSFX;
            jetSFXSource.Play();
            isMoving = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Moving calculation
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

    //Player Dead
    private void Die()
    {
        deadSFXSource.PlayOneShot(deadSFX);
        isAlive = false;
        playerAnim.SetBool("Dead", true);
        Destroy(gameObject, playerAnim.GetCurrentAnimatorStateInfo(0).length - 3.2f);
    }

    //Call DIe() function when collide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive && collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }      
    }
}
