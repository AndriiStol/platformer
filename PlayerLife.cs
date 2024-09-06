using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float fallDeathDistance = 10f;
    [SerializeField] private AudioSource deathAudioSource; // Присоедините аудио источник к этому полю

    private Animator anim;
    private Rigidbody2D rb;
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isDead && transform.position.y < -fallDeathDistance)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        PlayDeathSound(); // Воспроизводим звук смерти
    }

    private void PlayDeathSound()
    {
        if (deathAudioSource != null)
        {
            deathAudioSource.Play(); // Воспроизводим звук
        }
    }

    public void OnDeathAnimationComplete()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
