using System.Net.Mail;
using TMPro;
using System.Collections;
using UnityEngine;

public class Level_3_Terminal : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject terminalUI;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject eButton;
    [SerializeField] private Player_movement player_Movement;
    [SerializeField] private Player_CameraRotation player_CameraRotation;
    [SerializeField] private Animator door_1;
    [SerializeField] private Animator firstRoomRobot;
    [SerializeField] private Animator door_2;
    [SerializeField] private Animator SecondRoomRobotOne;
    [SerializeField] private Animator SecondRoomRoboTwo;
    [SerializeField] private Animator door_3;
    [SerializeField] private Animator ThirdRoomRobot;
    [SerializeField] private Animator door_4;
    [SerializeField] private Animator FourthRoomRobot;

    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;
    private Coroutine messageCoroutine;

    private bool isInTrigger = false;
    private bool isTerminalActive = false;

    // Счетчики для Terminal_3
    private int goForward = 0;
    private int turnRight = 0;
    private int turnLeft = 0;
    private int counter = 0;

    // Новые строки для сада (можно менять)
    private string[] gardenRows = {
        "FlowerWFlowerW",
        "WFlowerFlower",
        "FlowerFlowerW",
        "WFlowerWFlower"
    };

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
        string inputText = inputField.text.Trim();

        switch (gameObject.name)
        {
            case "Terminal_1":
                ProcessTerminal1Input(inputText);
                break;

            case "Terminal_2":
                ProcessTerminal2Input(inputText);
                break;

            case "Terminal_3":
                ProcessTerminal3Input(inputText);
                break;

            case "Terminal_4":
                SolveGardenerPuzzle(inputText);
                break;

            default:
                Debug.Log("Ошибка: Терминал не опознан.");
                break;
        }

        // Очищаем поле ввода после обработки
        inputField.text = "";
    }

    private void ProcessTerminal1Input(string inputText)
    {
        if (inputText == "notTouchTheWall()goForward()tapTheButton()" || inputText == "notTouchTheWall() goForward() tapTheButton()")
        {
            Debug.Log("Все проверки пройдены!");
            door_1.SetTrigger("DoorOpen");
            firstRoomRobot.SetTrigger("Correct");
            ShowCongratulationsMessage();
        }
        else
        {
            ShowFailMessage();
            Debug.Log("Ошибка: Неверный ввод!");
        }
    }

    private void ProcessTerminal2Input(string inputText)
    {
        if (inputText == "notSeeTheButton()goForward()tapthebutton()" || inputText == "notSeeTheButton() goForward() tapthebutton()")
        {
            Debug.Log("Все проверки пройдены!");
            door_2.SetTrigger("DoorOpen");
            SecondRoomRobotOne.SetTrigger("Correct");
            SecondRoomRoboTwo.SetTrigger("Correct");
            ShowCongratulationsMessage();
        }
        else
        {
            ShowFailMessage();
            Debug.Log("Ошибка: Неверный ввод!");
        }
    }

    private void ProcessTerminal3Input(string inputText)
    {
        switch (inputText)
        {
            case "goForward()":
                goForward++;
                counter++;
                Debug.Log("+1 to goForward");
                break;

            case "turnRight()":
                turnRight++;
                counter++;
                Debug.Log("+1 to turnRight");
                break;

            case "turnLeft()":
                turnLeft++;
                counter++;
                Debug.Log("+1 to turnLeft");
                break;

            default:
                ShowFailMessage();
                Debug.Log("Ошибка: Неверный ввод! Ожидается 'goForward()', 'turnRight()', или 'TurnLeft()'");
                return;
        }

        // Проверяем условия после обновления счетчиков
        if (turnLeft == 2 && turnRight == 2 && goForward == 3 && counter == 7)
        {
            door_3.SetTrigger("DoorOpen");
            ThirdRoomRobot.SetTrigger("Correct");
            ShowCongratulationsMessage();
            Debug.Log("Успех! Все условия выполнены.");

            ResetCounters();
        } else if (counter > 7)
        {
            ShowFailMessage();
            goForward = 0;
            turnRight = 0;
            turnLeft = 0;
            counter = 0;
        }
    }

    private void ResetCounters()
    {
        goForward = 0;
        turnRight = 0;
        turnLeft = 0;
    }

    private void SolveGardenerPuzzle(string inputText)
    {
        if (inputText == "contains")
        {
            Debug.Log("Введено правильное слово!");
            door_4.SetTrigger("DoorOpen");
            FourthRoomRobot.SetTrigger("Correct");
            ShowCongratulationsMessage();
        }
        else
        {
            ShowFailMessage();
            Debug.Log("Введено неверное слово!");
        }
    }

    private void ShowCongratulationsMessage()
    {
        if (!congratulationsMessage.activeSelf)
        {
            Debug.Log("Показ поздравительного сообщения");
            HideAllMessages();
            congratulationsMessage.SetActive(true);
            messageCoroutine = StartCoroutine(HideAfterDelay(5f));
        }
    }

    private void ShowFailMessage()
    {
        if (!failMessage.activeSelf)
        {
            Debug.Log("Показ сообщения об ошибке");
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
        Debug.Log("Корутина запущена");
        yield return new WaitForSeconds(delay);
        Debug.Log("Корутина завершена");
        HideAllMessages();
    }
}
