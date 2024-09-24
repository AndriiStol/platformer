using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;

    private int collectedBananas = 0;
    public GameObject levelCompletePanel;
    public TMPro.TextMeshProUGUI bananaCountText;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        levelCompletePanel.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;

            collectedBananas = FindObjectOfType<ItemCollector>().GetCollectedBananas();

            ShowLevelCompletePanel();

            
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;

            FindObjectOfType<LevelController>().OnLevelComplete();

        }
    }

    private void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
        bananaCountText.text = "bAnanas Collected: " + collectedBananas;
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
