using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenTerminal : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject terminalUI; // ������ �� UI ���������
    [SerializeField] private TMP_InputField inputField; // ���� ����� �����
    [SerializeField] private GameObject eButton; // ��������� ������ E
    [SerializeField] private Player_movement player_Movement;
    [SerializeField] private Player_CameraRotation player_CameraRotation;
    [SerializeField] private Animator door;

    private bool isInTrigger = false; // � ���� ���������
    private bool isTerminalActive = false; // �������� ������

    private void Start()
    {
        terminalUI.SetActive(false);
        eButton.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // �������� ���������
        if (isInTrigger && Input.GetKeyDown(KeyCode.E) && !isTerminalActive)
        {
            ShowTerminal();
        }

        // �������� ���������
        if (isTerminalActive && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseTerminal();
        }
    }

    private void ShowTerminal()
    {
        isTerminalActive = true;
        terminalUI.SetActive(true);
        inputField.text = "";
        eButton.SetActive(false);
        player_Movement.enabled = false;
        player_CameraRotation.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CloseTerminal()
    {
        isTerminalActive = false;
        terminalUI.SetActive(false);
        eButton?.SetActive(true);
        player_Movement.enabled = true;
        player_CameraRotation.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ValidateInput(); // �������� ��������� ������ ��� ��������
    }

    // ���������� ��� ��������� ������ � ���� ����� (����� ���������� � ������)
    public void ValidateInput()
    {
        if (int.TryParse(inputField.text, out int number))
        {
            if (number > 5)
            {
                door.SetTrigger("Door-1");
                Debug.Log("�����! ������� �����: " + number);
            }
            else
            {
                Debug.Log("������: ����� ������ ���� ������ 5");
            }
        }
        else
        {
            Debug.Log("������: ������� ����� �����");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInTrigger = true;
            eButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInTrigger = false;
            eButton.SetActive(false);

            if (isTerminalActive)
            {
                CloseTerminal();
            }
        }
    }
}
