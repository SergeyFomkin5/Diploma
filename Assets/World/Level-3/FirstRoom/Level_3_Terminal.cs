using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_3_Terminal : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject terminalUI; // Ссылка на UI терминала
    [SerializeField] private TMP_InputField inputField; // Поле ввода числа
    [SerializeField] private GameObject eButton; // Подсказка кнопки E
    [SerializeField] private Player_movement player_Movement;
    [SerializeField] private Player_CameraRotation player_CameraRotation;
    [SerializeField] private Animator door_1;
    [SerializeField] private Animator firstRoomRobot;
    //[SerializeField] private Animator door_2;
    //[SerializeField] private Animator door_3;

    private bool isInTrigger = false; // В зоне терминала
    private bool isTerminalActive = false; // Терминал открыт

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

        // Проверка ввода при нажатии Enter
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
        string inputText = inputField.text.Trim(); // Убираем лишние пробелы и приводим к нижнему регистру
        string[] words = inputText.Split(' '); // Разбиваем текст на отдельные слова

        bool hasNotTouchTheWall = false;
        bool hasGoForward = false;
        bool hasTapTheButton = false;


        switch (gameObject.name)
        {
            case "Terminal_1":
                // Проверка числа для первого терминала
                foreach (string word in words)
                {
                    if (word == "notTouchTheWall()") // Сравниваем с нижним регистром
                    {
                        hasNotTouchTheWall = true;
                    }
                    else if (word == "goForward()") // Сравниваем с нижним регистром
                    {
                        hasGoForward = true;
                    }
                    else if (word == "tapTheButton()") // Сравниваем с нижним регистром
                    {
                        hasTapTheButton = true;
                    }
                }

                if (hasNotTouchTheWall && hasGoForward && hasTapTheButton)
                {
                    door_1.SetTrigger("DoorOpen");
                    firstRoomRobot.SetTrigger("Correct");
                    Debug.Log("Успех!");
                }
                else
                {
                    Debug.Log("Ошибка");
                }
                break;

            //case "Terminal_2":
            //    // Проверка слова для второго терминала
            //    if (inputText == "!isWorking")
            //    {
            //        door_2.SetTrigger("Door-2"); // Убедитесь в существовании Door-2 анимации!
            //        Debug.Log("Успех! Введено правильное слово.");
            //    }
            //    else
            //    {
            //        Debug.Log("Ошибка: Введите '!isWorking'");
            //    }
            //    break;

            //case "Terminal_3":
            //    // Проверка цвета для третьего терминала
            //    switch (inputText.ToLower()) // Делаем ввод нечувствительным к регистру
            //    {
            //        case "red green purple":
            //            door_3.SetTrigger("Door-3");
            //            Debug.Log("Успех! Введено правильное слово.");
            //            break;
            //        default:
            //            Debug.Log("Ошибка: Введите 'red', 'green' или 'purple'");
            //            break;
            //    }
            //    break;
            //case "Terminal_4":
            //    // Проверка цвета для третьего терминала
            //    switch (inputText.ToLower()) // Делаем ввод нечувствительным к регистру
            //    {
            //        case "red green purple":
            //            door_3.SetTrigger("Door-3");
            //            Debug.Log("Успех! Введено правильное слово.");
            //            break;
            //        default:
            //            Debug.Log("Ошибка: Введите 'red', 'green' или 'purple'");
            //            break;
            //    }
            //    break;

            default:
                Debug.Log("Ошибка: Терминал не опознан.");
                break;
        }
    }
}
