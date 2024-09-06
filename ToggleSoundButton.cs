using UnityEngine;
using UnityEngine.UI;

public class ToggleSoundButton : MonoBehaviour
{
    private Button toggleButton;
    private Text buttonText;

    private void Start()
    {
        toggleButton = GetComponent<Button>();
        buttonText = toggleButton.GetComponentInChildren<Text>();

        UpdateButtonText();

        toggleButton.onClick.AddListener(ToggleSound);
    }

    private void UpdateButtonText()
    {
        if (SoundManager.Instance.IsSoundEnabled())
        {
            buttonText.text = "Sound: ON";
        }
        else
        {
            buttonText.text = "Sound: OFF";
        }
    }

    private void ToggleSound()
    {
        SoundManager.Instance.ToggleSound();
        UpdateButtonText();
    }
}
