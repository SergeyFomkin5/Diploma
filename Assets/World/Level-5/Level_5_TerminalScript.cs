using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_5_TerminalScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject terminalUI;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject eButton;
    [SerializeField] private Player_movement player_Movement;
    [SerializeField] private Player_CameraRotation player_CameraRotation;
    [SerializeField] private Animator door_1;
    [SerializeField] private Animator RedPlatform;
    [SerializeField] private Animator BluePlatform;
    [SerializeField] private Animator GreenPlatform;

    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;
    private Coroutine messageCoroutine;

    private bool isInTrigger = false;
    private bool isTerminalActive = false;

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

        if (inputText == "red blue green")
        {
            door_1.SetTrigger("DoorOpen");
            ShowCongratulationsMessage();
            Debug.Log("�����!");
            RedPlatform.SetTrigger("Red");
            BluePlatform.SetTrigger("Blue");
            GreenPlatform.SetTrigger("Green");
        }
        else
        {
            ShowFailMessage();
            Debug.Log("������� ������� �����");
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
