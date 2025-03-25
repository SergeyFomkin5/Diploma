using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_6_TerminalScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject terminalUI;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject eButton;
    [SerializeField] private Player_movement player_Movement;
    [SerializeField] private Player_CameraRotation player_CameraRotation;
    [SerializeField] private Animator door_1;

    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;
    private Coroutine messageCoroutine;


    private bool isInTrigger = false;
    private bool isTerminalActive = false;

    string RobotName = "string";
    bool RobotNameCheck = false;
    string RobotJob = "engineer";
    bool RobotJobCheck = false;
    int RobotAuthLevel = 2;
    bool RobotAuthLevelCheck = false;
    string ClassCreating = "public void";
    bool ClassCreatingCheck = false;

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
        if (isInTrigger && Input.GetKeyDown(KeyCode.E) && !isTerminalActive)
        {
            ShowTerminal();
        }

        if (isTerminalActive && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseTerminal();
        }

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
    }

    private void ValidateInput()
    {
        string inputText = inputField.text.Trim().ToLower();

        if (gameObject.name == "Terminal")
        {
            TerminalProccess(inputText);
        }
        else
        {
            Debug.Log("������: �������� �� �������.");
        }

        inputField.text = "";

    }

    private void TerminalProccess(string inputText)
    {

        if (inputText == RobotName)
        {
            Debug.Log("��� �����");
            RobotNameCheck = true;
        }
        else if (inputText == RobotJob)
        {
            Debug.Log("������ �����");
            RobotJobCheck = true;
        }
        else if (int.TryParse(inputText, out int number))
        {
            if (number == RobotAuthLevel)
            {
                Debug.Log("������� ������� �����");
                RobotAuthLevelCheck = true;
            }
        }
        else if (inputText == ClassCreating)
        {
            Debug.Log("����������� ������ �����");
            ClassCreatingCheck = true;
        }
        else
        {
            ShowFailMessage();
            Debug.Log("������, ���-�� �������");
        }

        if (RobotNameCheck && RobotJobCheck && RobotAuthLevelCheck && ClassCreatingCheck)
        {
            door_1.SetTrigger("DoorOpen");
            ShowCongratulationsMessage();
            Debug.Log("�����");
            //Fabricator.SetTrigger("DoorOpen");

        }


    }

    private void ShowCongratulationsMessage()
    {
        if (!congratulationsMessage.activeSelf)
        {
            Debug.Log("����� ���������������� ���������");
            HideAllMessages();
            congratulationsMessage.SetActive(true);
            messageCoroutine = StartCoroutine(HideAfterDelay(5f));
        }
    }

    private void ShowFailMessage()
    {
        if (!failMessage.activeSelf)
        {
            Debug.Log("����� ��������� �� ������");
            HideAllMessages();
            failMessage.SetActive(true);
            messageCoroutine = StartCoroutine(HideAfterDelay(5f));
        }
    }
    private void HideAllMessages()
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
            messageCoroutine = null;
        }
        failMessage.SetActive(false);
        congratulationsMessage.SetActive(false);
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        Debug.Log("�������� ��������");
        yield return new WaitForSeconds(delay);
        Debug.Log("�������� ���������");
        HideAllMessages();
    }
}
