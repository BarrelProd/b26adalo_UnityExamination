using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public int health;
    public float playerSpeed;
    public float playerJumpForce;
    public bool grounded;
    public bool interacting;
    public bool interactable;
    public Rigidbody2D playerRigidbody;
    public SpriteRenderer playerSpriteRenderer;
    public Animator playerAnimator;
    public Image hitPointOne;
    public Image hitPointTwo;
    public Image hitPointThree;
    public Sprite emptyHitPoint;
    public Sprite fullHitPoint;
    
    void Start()
    {
        health = 3;
        interacting = false;
    }
    
    void Update()
    {
        Movement();
        HealthControl();
        PlayerInteract();
    }
    
    void Movement()
    {
        if (interacting == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
                playerSpriteRenderer.flipX = false;
                playerAnimator.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
                playerSpriteRenderer.flipX = true;
                playerAnimator.SetBool("isWalking", true);
            }
            else
            {
                playerAnimator.SetBool("isWalking", false);
            }
        
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                playerRigidbody.AddForce( new Vector3(0, 1, 0) * playerJumpForce);
            }
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

    void PlayerInteract()
    {
        if (interacting == true && Input.GetKeyDown(KeyCode.E))
        {
            interacting = false;
        }
        else if (interactable == true && interacting == false && Input.GetKeyDown(KeyCode.E))
        {
            interacting = true;
        }
        
    }

    void PlayerDeath()
    {
        playerAnimator.SetBool("isDead", true);
        interacting = true;
        SceneManager.LoadScene(1);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interact"))
        {
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interact"))
        {
            interactable = false;
        }
    }
}
