using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    public Joystick joystick;


    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

 [SerializeField] private float climbSpeed = 5f; 
    private bool isClimbing = false; 

    private void Update()
    {
        dirX = joystick.Horizontal;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (isClimbing)
        {
            
            float dirY = joystick.Vertical;
            rb.velocity = new Vector2(rb.velocity.x, dirY * climbSpeed);
        }

        UpdateAnimationState();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {

            isClimbing = true;
            rb.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {

            isClimbing = false;
            rb.gravityScale = 3f;
        }
    }

    public void OnJumpButtonDown ()
    {
        if ( IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
