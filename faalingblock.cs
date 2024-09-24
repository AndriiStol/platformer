using UnityEngine;
using System.Collections;

public class faalingblock : MonoBehaviour
{
    public float bounceForce = 10f; 
    public float detectRadius = 1.5f; 
    public float jumpCooldown = 2f; 
    public LayerMask playerLayer; 

    private bool isGrounded = true; 
    private bool canJump = true; 
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canJump)
        {
           
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectRadius, playerLayer);

            if (playerCollider != null)
            {
               
                if (isGrounded)
                {
                    rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                    isGrounded = false;
                    canJump = false;
                    Invoke("ResetJump", jumpCooldown);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == ("Terrain"))
        {
            isGrounded = true;
        }
    }

    private void ResetJump()
    {
        canJump = true;
    }

    

}


