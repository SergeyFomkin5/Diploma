using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Level_2_OpenTerminal : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject terminalUI; // ������ �� UI ���������
    [SerializeField] private TMP_InputField inputField; // ���� ����� �����
    [SerializeField] private GameObject eButton; // ��������� ������ E
    [SerializeField] private Player_movement player_Movement;
    [SerializeField] private Player_CameraRotation player_CameraRotation;
    [SerializeField] private Animator door_1;
    [SerializeField] private Animator door_2;
    [SerializeField] private Animator door_3;
    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;
    public PauseScript isPauseActive;
    private Coroutine messageCoroutine;

    private bool isInTrigger = false; // � ���� ���������
    public bool isTerminalActive = false; // �������� ������

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
        if (isInTrigger && Input.GetKeyDown(KeyCode.E) && !isTerminalActive && !isPauseActive.isPaused)
        {
            ShowTerminal();
        }

        // �������� ���������
        if (isTerminalActive && Input.GetKeyDown(KeyCode.Escape) && isPauseActive.isPaused)
        {
            CloseTerminal();
        }

        // �������� ����� ��� ������� Enter
        if (isTerminalActive && Input.GetKeyDown(KeyCode.Return))
        {
            ValidateInput();
        }
    }

    public void ShowTerminal()
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
        string inputText = inputField.text.Trim(); // ������� ������ �������

        switch (gameObject.name)
        {
            case "Terminal_1":
                // �������� ����� ��� ������� ���������
                if (int.TryParse(inputText, out int number))
                {
                    if (number > 5)
                    {
                        door_1.SetTrigger("Door-1");
                        ShowCongratulationsMessage();
                        Debug.Log($"�����! ������� �����: {number}");
                    }
                    else
                    {
                        ShowFailMessage();
                        Debug.Log("������: ����� ������ ���� ������ 5");
                    }
                }
                else
                {
                    ShowFailMessage();
                    Debug.Log("������: ������� ����� �����");
                }
                break;

            case "Terminal_2":
                // �������� ����� ��� ������� ���������
                if (inputText == "!isWorking()")
                {
                    door_2.SetTrigger("Door-2"); // ��������� � ������������� Door-2 ��������!
                    ShowCongratulationsMessage();
                    Debug.Log("�����! ������� ���������� �����.");
                }
                else
                {
                    ShowFailMessage();
                    Debug.Log("������: ������� '!isWorking'");
                }
                break;

            case "Terminal_3":
                // �������� ����� ��� �������� ���������
                switch (inputText.ToLower()) // ������ ���� ���������������� � ��������
                {
                    case "red green purple":
                        door_3.SetTrigger("Door-3");
                        ShowCongratulationsMessage();
                        Debug.Log("�����! ������� ���������� �����.");
                        break;
                    default:
                        ShowFailMessage();
                        Debug.Log("������: ������� 'red', 'green' ��� 'purple'");
                        break;
                }
                break;

            default:
                ShowFailMessage();
                Debug.Log("������: �������� �� �������.");
                break;
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
