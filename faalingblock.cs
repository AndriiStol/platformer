using UnityEngine;
using System.Collections;

public class faalingblock : MonoBehaviour
{
    public float bounceForce = 10f; // Сила прыжка ловушки
    public float detectRadius = 1.5f; // Радиус обнаружения игрока
    public float jumpCooldown = 2f; // Задержка между прыжками
    public LayerMask playerLayer; // Слой, на котором находятся игроки

    private bool isGrounded = true; // Флаг для отслеживания состояния на земле
    private bool canJump = true; // Флаг для проверки возможности прыжка
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canJump)
        {
            // Проверяем наличие игроков в радиусе обнаружения
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectRadius, playerLayer);

            if (playerCollider != null)
            {
                // Применяем силу прыжка, если ловушка на земле
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
        // Проверяем, столкнулась ли ловушка с землей
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


