using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Joystick joystick; // ���������� ��� Joystick � ��� ����
    public Button jumpButton; // ���������� ���� ������ ������ � ��� ����

    private void Start()
    {
        // � ������ ������ �������� Joystick � ������ ������
        joystick.gameObject.SetActive(true);
        jumpButton.gameObject.SetActive(true);
    }

    public void OnLevelComplete()
    {
        // �� ������ ���� ������� ����� ���������� ������
        // ��������� Joystick � ������ ������
        joystick.gameObject.SetActive(false);
        jumpButton.gameObject.SetActive(false);
    }
}
