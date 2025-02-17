using TMPro;
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

    private bool isInTrigger = false;
    private bool isTerminalActive = false;

    // Счетчики для Terminal_3
    private int goForward = 0;
    private int turnRight = 0;
    private int turnLeft = 0;

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
        string inputText = inputField.text.Trim().ToLower();

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
        if (inputText == "nottouchthewall()" || inputText == "goleft()" || inputText == "tapthebutton()")
        {
            Debug.Log("Все проверки пройдены!");
            door_1.SetTrigger("DoorOpen");
            firstRoomRobot.SetTrigger("Correct");
        }
        else
        {
            Debug.Log("Ошибка: Неверный ввод!");
        }
    }

    private void ProcessTerminal2Input(string inputText)
    {
        if (inputText == "goleft()" || inputText == "goright()" || inputText == "tapthebutton()")
        {
            Debug.Log("Все проверки пройдены!");
            door_2.SetTrigger("DoorOpen");
            SecondRoomRobotOne.SetTrigger("Correct");
            SecondRoomRoboTwo.SetTrigger("Correct");
        }
        else
        {
            Debug.Log("Ошибка: Неверный ввод!");
        }
    }

    private void ProcessTerminal3Input(string inputText)
    {
        switch (inputText)
        {
            case "goforward()":
                goForward++;
                Debug.Log("+1 to goForward");
                break;

            case "turnright()":
                turnRight++;
                Debug.Log("+1 to turnRight");
                break;

            case "turnleft()":
                turnLeft++;
                Debug.Log("+1 to turnLeft");
                break;

            default:
                Debug.Log("Ошибка: Неверный ввод! Ожидается 'goForward()', 'turnRight()', или 'TurnLeft()'");
                return;
        }

        // Проверяем условия после обновления счетчиков
        if (turnLeft == 2 && turnRight == 2 && goForward == 3)
        {
            door_3.SetTrigger("DoorOpen");
            ThirdRoomRobot.SetTrigger("Correct");
            Debug.Log("Успех! Все условия выполнены.");

            ResetCounters();
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
        }
        else
        {
            Debug.Log("Введено неверное слово!");
        }
    }
}
