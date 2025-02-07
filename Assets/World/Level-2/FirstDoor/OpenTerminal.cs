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
    [SerializeField] private Animator door;

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

    // Вызывается при изменении текста в поле ввода (можно подключить к кнопке)
    public void ValidateInput()
    {
        if (int.TryParse(inputField.text, out int number))
        {
            if (number > 5)
            {
                door.SetTrigger("Door-1");
                Debug.Log("Успех! Введено число: " + number);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInTrigger = true;
            eButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInTrigger = false;
            eButton.SetActive(false);

            if (isTerminalActive)
            {
                CloseTerminal();
            }
        }
    }
}
