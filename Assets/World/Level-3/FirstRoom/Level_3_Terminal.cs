using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_3_Terminal : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject terminalUI; // ������ �� UI ���������
    [SerializeField] private TMP_InputField inputField; // ���� ����� �����
    [SerializeField] private GameObject eButton; // ��������� ������ E
    [SerializeField] private Player_movement player_Movement;
    [SerializeField] private Player_CameraRotation player_CameraRotation;
    [SerializeField] private Animator door_1;
    [SerializeField] private Animator firstRoomRobot;
    //[SerializeField] private Animator door_2;
    //[SerializeField] private Animator door_3;

    private bool isInTrigger = false; // � ���� ���������
    private bool isTerminalActive = false; // �������� ������

    private void Start()
    {
        terminalUI.SetActive(false);
        eButton.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = true;
            eButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = false;
            eButton.SetActive(false);

            if (isTerminalActive)
            {
                CloseTerminal();
            }
        }
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

        // �������� ����� ��� ������� Enter
        if (isTerminalActive && Input.GetKeyDown(KeyCode.Return))
        {
            ValidateInput();
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

        // ������� ����� ValidateInput() �� CloseTerminal()
    }

    private void ValidateInput()
    {
        string inputText = inputField.text.Trim(); // ������� ������ ������� � �������� � ������� ��������
        string[] words = inputText.Split(' '); // ��������� ����� �� ��������� �����

        bool hasNotTouchTheWall = false;
        bool hasGoForward = false;
        bool hasTapTheButton = false;


        switch (gameObject.name)
        {
            case "Terminal_1":
                // �������� ����� ��� ������� ���������
                foreach (string word in words)
                {
                    if (word == "notTouchTheWall()") // ���������� � ������ ���������
                    {
                        hasNotTouchTheWall = true;
                    }
                    else if (word == "goForward()") // ���������� � ������ ���������
                    {
                        hasGoForward = true;
                    }
                    else if (word == "tapTheButton()") // ���������� � ������ ���������
                    {
                        hasTapTheButton = true;
                    }
                }

                if (hasNotTouchTheWall && hasGoForward && hasTapTheButton)
                {
                    door_1.SetTrigger("DoorOpen");
                    firstRoomRobot.SetTrigger("Correct");
                    Debug.Log("�����!");
                }
                else
                {
                    Debug.Log("������");
                }
                break;

            //case "Terminal_2":
            //    // �������� ����� ��� ������� ���������
            //    if (inputText == "!isWorking")
            //    {
            //        door_2.SetTrigger("Door-2"); // ��������� � ������������� Door-2 ��������!
            //        Debug.Log("�����! ������� ���������� �����.");
            //    }
            //    else
            //    {
            //        Debug.Log("������: ������� '!isWorking'");
            //    }
            //    break;

            //case "Terminal_3":
            //    // �������� ����� ��� �������� ���������
            //    switch (inputText.ToLower()) // ������ ���� ���������������� � ��������
            //    {
            //        case "red green purple":
            //            door_3.SetTrigger("Door-3");
            //            Debug.Log("�����! ������� ���������� �����.");
            //            break;
            //        default:
            //            Debug.Log("������: ������� 'red', 'green' ��� 'purple'");
            //            break;
            //    }
            //    break;
            //case "Terminal_4":
            //    // �������� ����� ��� �������� ���������
            //    switch (inputText.ToLower()) // ������ ���� ���������������� � ��������
            //    {
            //        case "red green purple":
            //            door_3.SetTrigger("Door-3");
            //            Debug.Log("�����! ������� ���������� �����.");
            //            break;
            //        default:
            //            Debug.Log("������: ������� 'red', 'green' ��� 'purple'");
            //            break;
            //    }
            //    break;

            default:
                Debug.Log("������: �������� �� �������.");
                break;
        }
    }
}
