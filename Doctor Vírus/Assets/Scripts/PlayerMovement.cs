using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Physics
    Vector2 movement;
    public float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = true;
    #endregion

    private Animator anim;

    public bool isInteracting;

    [SerializeField]
    private List<string> inventoryItems = new List<string>();

    [SerializeField]
    private AudioClip playerDeath;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
        HandleInteract();
        HandlePauseMenu();
    }

    void FixedUpdate()
    {
        // Moves the character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        if (movement.x > 0f || movement.y > 0f)
        {
            anim.SetBool("running", true);
        }

        if (movement.x < 0f || movement.y < 0f)
        {
            anim.SetBool("running", true);
        }

        if (movement.x == 0f && movement.y == 0f)
        {
            anim.SetBool("running", false);
        }
    }

    public void AddItem(string itemName)
    {
        inventoryItems.Add(itemName);
    }

    public bool HaveItem(string itemName)
    {
        // If the item name is in the inventory -> TRUE
        // If not -> FALSE
        return inventoryItems.Contains(itemName);
    }

    public void HandleInteract()
    {
        if (Input.GetButtonDown("Interact"))
        {
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
        }
    }

    private void HandleInput()
    {
        // Reads the input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Verifies if the player is facing right or left
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if (direction.x > 0 && !facingRight || direction.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void HandlePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.ShowPauseMenu();
        }
    }

    private void Flip()
    {
        // Turns the player
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
    private void PlayDeathSound()
    {
        if (playerDeath)
                AudioSource.PlayClipAtPoint(playerDeath, transform.position);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Virus")
        {
            PlayDeathSound();
            GameManager.instance.ShowGameOver();
            Destroy(gameObject);
            Time.timeScale = 0;
        }

        if (other.gameObject.tag == "Projectile")
        {
            PlayDeathSound();
            GameManager.instance.ShowGameOver();
            Destroy(gameObject);
            Time.timeScale = 0;
        }

        if (other.gameObject.tag == "Bacterium")
        {
            PlayDeathSound();
            GameManager.instance.ShowGameOver();
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
