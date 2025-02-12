using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenTerminal : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject terminalUI; // Ссылка на UI терминала
    [SerializeField] private TMP_InputField inputField; // Поле ввода числа
    [SerializeField] private GameObject eButton; // Подсказка кнопки E
    [SerializeField] private Player_movement player_Movement;
    [SerializeField] private Player_CameraRotation player_CameraRotation;
    [SerializeField] private Animator door_1;
    [SerializeField] private Animator door_2;
    [SerializeField] private Animator door_3;

    private bool isInTrigger = false; // В зоне терминала
    private bool isTerminalActive = false; // Терминал открыт

    private void Start()
    {
        terminalUI.SetActive(false);
        eButton.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Открытие терминала
        if (isInTrigger && Input.GetKeyDown(KeyCode.E) && !isTerminalActive)
        {
            ShowTerminal();
        }

        // Закрытие терминала
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

        ValidateInput(); // Проверка введенных данных при закрытии
    }

    private void ValidateInput()
    {
        string inputText = inputField.text.Trim(); // Убираем лишние пробелы

        switch (gameObject.name)
        {
            case "Terminal (1)":
                // Проверка числа для первого терминала
                if (int.TryParse(inputText, out int number))
                {
                    if (number > 5)
                    {
                        door_1.SetTrigger("Door-1");
                        Debug.Log($"Успех! Введено число: {number}");
                    }
                    else
                    {
                        Debug.Log("Ошибка: Число должно быть больше 5");
                    }
                }
                else
                {
                    Debug.Log("Ошибка: Введите целое число");
                }
                break;

            case "Terminal (2)":
                // Проверка слова для второго терминала
                if (inputText == "!isWorking")
                {
                    door_2.SetTrigger("Door-2");
                    Debug.Log("Успех! Введено правильное слово.");
                }
                else
                {
                    Debug.Log("Ошибка: Введите '!isWorking'");
                }
                break;

            case "Terminal (3)": // Исправлено на "Terminal3"
                // Проверка цвета для третьего терминала
                switch (inputText.ToLower()) // Делаем ввод нечувствительным к регистру
                {
                    case "red":
                    case "green":
                    case "purple":
                        door_3.SetTrigger("Door-3");
                        Debug.Log("Успех! Введено правильное слово.");
                        break;
                    default:
                        Debug.Log("Ошибка: Введите 'red', 'green' или 'purple'");
                        break;
                }
                break;

            default:
                Debug.Log("Ошибка: Терминал не опознан.");
                break;
        }
    }
}
