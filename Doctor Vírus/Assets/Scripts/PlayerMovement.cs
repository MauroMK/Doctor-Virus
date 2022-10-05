using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;

    public float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = true;

    #region Dash Variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 4f;
    private float dashingTime = 0.1f;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        HandleDash();
    }

    private void HandleInput()
    {
        // Reads the input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Verifies if the player is in the right position
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

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        // Moves the character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
