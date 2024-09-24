using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Joystick joystick; 
    public Button jumpButton; 

    private void Start()
    {
        
        joystick.gameObject.SetActive(true);
        jumpButton.gameObject.SetActive(true);
    }

    public void OnLevelComplete()
    {

        joystick.gameObject.SetActive(false);
        jumpButton.gameObject.SetActive(false);
    }
}
