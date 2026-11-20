using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float playerSpeed;
    public float playerJumpForce;
    public bool grounded;
    public Rigidbody2D playerRigidbody;
    public SpriteRenderer playerSpriteRenderer;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Movement();
    }
    
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            playerSpriteRenderer.flipX = false;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
            playerSpriteRenderer.flipX = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRigidbody.AddForce( new Vector3(0, 1, 0) * playerJumpForce);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
