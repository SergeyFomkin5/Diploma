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

    private bool isInTrigger = false;
    private bool isTerminalActive = false;

    // Счетчики для Terminal_3
    private int goForward = 0;
    private int turnRight = 0;
    private int turnLeft = 0;

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

        // Удаляем вызов ValidateInput() из CloseTerminal()
    }

    private void ValidateInput()
    {
        string inputText = inputField.text.Trim(); // Убираем лишние пробелы

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

            default:
                Debug.Log("Ошибка: Терминал не опознан.");
                break;
        }

        // Очищаем поле ввода после обработки
        inputField.text = "";
    }

    private void ProcessTerminal1Input(string inputText)
    {
        if (inputText == "notTouchTheWall()" || inputText == "goLeft()" || inputText == "tapTheButton()")
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
        if (inputText == "goLeft()" || inputText == "goRight()" || inputText == "tapTheButton()")
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
        // Обновляем счетчики в зависимости от введенной команды
        if (inputText == "goForward()")
        {
            goForward++;
            Debug.Log("+1 to goForward");
        }
        else if (inputText == "turnRight()")
        {
            turnRight++;
            Debug.Log("+1 to turnRight");
        }
        else if (inputText == "turnLeft()")
        {
            turnLeft++;
            Debug.Log("+1 to turnLeft");
        }
        else
        {
            Debug.Log("Ошибка: Неверный ввод! Ожидается 'goForward()', 'turnRight()', или 'turnLeft()'");
            return; // Прерываем выполнение, если команда неверная
        }

        // Проверяем условия после обновления счетчиков
        if (turnLeft == 2 && turnRight == 2 && goForward == 3)
        {
            door_3.SetTrigger("DoorOpen");
            ThirdRoomRobot.SetTrigger("Correct");
            Debug.Log("Успех! Все условия выполнены.");

            // Сбрасываем счетчики, если нужно повторное использование терминала
            ResetCounters();
        }
    }

    private void ResetCounters()
    {
        goForward = 0;
        turnRight = 0;
        turnLeft = 0;
    }
}
