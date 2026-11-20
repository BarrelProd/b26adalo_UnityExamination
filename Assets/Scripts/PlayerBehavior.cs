using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public int health;
    public float playerSpeed;
    public float playerJumpForce;
    public bool grounded;
    public Rigidbody2D playerRigidbody;
    public SpriteRenderer playerSpriteRenderer;
    public Image hitPointOne;
    public Image hitPointTwo;
    public Image hitPointThree;
    public Sprite emptyHitPoint;
    public Sprite fullHitPoint;
    
    void Start()
    {
        health = 3;
    }
    
    void Update()
    {
        Movement();
        HealthControl();
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

    void HealthControl()
    {
        if (health <= 0)
        {
            hitPointOne.sprite = emptyHitPoint;
            hitPointTwo.sprite = emptyHitPoint;
            hitPointThree.sprite = emptyHitPoint;
            PlayerDeath();
        }
        else if (health == 1)
        {
            hitPointOne.sprite = fullHitPoint;
            hitPointTwo.sprite = emptyHitPoint;
            hitPointThree.sprite = emptyHitPoint;
        }
        else if (health == 2)
        {
            hitPointOne.sprite = fullHitPoint;
            hitPointTwo.sprite = fullHitPoint;
            hitPointThree.sprite = emptyHitPoint;
        }
        else if (health == 3)
        {
            hitPointOne.sprite = fullHitPoint;
            hitPointTwo.sprite = fullHitPoint;
            hitPointThree.sprite = fullHitPoint;
        }
        
    }

    void PlayerDeath()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
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
