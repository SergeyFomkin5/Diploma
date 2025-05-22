using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Level_2_OpenTerminal : MonoBehaviour
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
    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;
    public PauseScript isPauseActive;
    private Coroutine messageCoroutine;

    private bool isInTrigger = false; // В зоне терминала
    public bool isTerminalActive = false; // Терминал открыт

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
        if (isInTrigger && Input.GetKeyDown(KeyCode.E) && !isTerminalActive && !isPauseActive.isPaused)
        {
            ShowTerminal();
        }

        // Закрытие терминала
        if (isTerminalActive && Input.GetKeyDown(KeyCode.Escape) && isPauseActive.isPaused)
        {
            CloseTerminal();
        }

        // Проверка ввода при нажатии Enter
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

        // Удаляем вызов ValidateInput() из CloseTerminal()
    }

    private void ValidateInput()
    {
        string inputText = inputField.text.Trim(); // Убираем лишние пробелы

        switch (gameObject.name)
        {
            case "Terminal_1":
                // Проверка числа для первого терминала
                if (int.TryParse(inputText, out int number))
                {
                    if (number > 5)
                    {
                        door_1.SetTrigger("Door-1");
                        ShowCongratulationsMessage();
                        Debug.Log($"Успех! Введено число: {number}");
                    }
                    else
                    {
                        ShowFailMessage();
                        Debug.Log("Ошибка: Число должно быть больше 5");
                    }
                }
                else
                {
                    ShowFailMessage();
                    Debug.Log("Ошибка: Введите целое число");
                }
                break;

            case "Terminal_2":
                // Проверка слова для второго терминала
                if (inputText == "!isWorking()")
                {
                    door_2.SetTrigger("Door-2"); // Убедитесь в существовании Door-2 анимации!
                    ShowCongratulationsMessage();
                    Debug.Log("Успех! Введено правильное слово.");
                }
                else
                {
                    ShowFailMessage();
                    Debug.Log("Ошибка: Введите '!isWorking'");
                }
                break;

            case "Terminal_3":
                // Проверка цвета для третьего терминала
                switch (inputText.ToLower()) // Делаем ввод нечувствительным к регистру
                {
                    case "red green purple":
                        door_3.SetTrigger("Door-3");
                        ShowCongratulationsMessage();
                        Debug.Log("Успех! Введено правильное слово.");
                        break;
                    default:
                        ShowFailMessage();
                        Debug.Log("Ошибка: Введите 'red', 'green' или 'purple'");
                        break;
                }
                break;

            default:
                ShowFailMessage();
                Debug.Log("Ошибка: Терминал не опознан.");
                break;
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
