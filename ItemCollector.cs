using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSound;

    public int GetCollectedBananas()
    {
        return cherries;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "bAnan: " + cherries;
            PlayCollectSound();
        }
    }

    private void PlayCollectSound()
    {
        if (collectSound != null)
        {
            collectSound.Play();
        }
    }
}
