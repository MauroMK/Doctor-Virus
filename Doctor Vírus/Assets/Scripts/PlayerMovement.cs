using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Vector2 movement;
    Vector2 mousePos;

    public float moveSpeed;
    public Camera cam;

    private Rigidbody2D rb;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 8f;
    private float dashingTime = 0.1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

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
        // Swap sprite direction, wether you're going right or left
        if(movement.x > 0)
        {
            transform.localScale = Vector2.one;
        }
        if(movement.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
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
