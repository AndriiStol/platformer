using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Joystick joystick; // Перетащите ваш Joystick в это поле
    public Button jumpButton; // Перетащите вашу кнопку прыжка в это поле

    private void Start()
    {
        // В начале уровня включаем Joystick и кнопку прыжка
        joystick.gameObject.SetActive(true);
        jumpButton.gameObject.SetActive(true);
    }

    public void OnLevelComplete()
    {
        // По вызову этой функции после завершения уровня
        // отключаем Joystick и кнопку прыжка
        joystick.gameObject.SetActive(false);
        jumpButton.gameObject.SetActive(false);
    }
}
