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

    #region Dash Variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 4f;
    private float dashingTime = 0.1f;
    #endregion

    public bool isInteracting;

    [SerializeField]
    private List<string> inventoryItems = new List<string>();

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        HandleDash();
        HandleInteract();
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        // Moves the character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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

    private void Flip()
    {
        // Turns the player
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && !isDashing)
        {
            Destroy(gameObject);
            // ShowGameOverScreen()
            // Set time to pause
        }
    }
}
