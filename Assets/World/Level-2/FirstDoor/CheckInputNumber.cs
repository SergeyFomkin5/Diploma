using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckInputNumber : MonoBehaviour
{
    public TMP_InputField inputField; // Поле для ввода числа
    public TMP_Text resultText; // Текст для отображения результата
    public GameObject therminalPanel; // Панель терминала
    public GameObject eButtonAction; // Подсказка "Нажмите E"
    public Collider therminalTriggerZone; // Зона триггера терминала

    private bool isPlayerInTrigger = false; // Флаг, находится ли игрок в зоне триггера

    void Update()
    {
        // Проверяем, нажата ли клавиша Enter (для отправки числа)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnSubmit();
        }

        // Проверяем, нажата ли клавиша E и игрок находится в зоне триггера
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInTrigger)
        {
            therminalPanel.SetActive(true); // Открываем панель терминала
            eButtonAction.SetActive(false); // Скрываем подсказку "Нажмите E"
            Debug.Log("Terminal panel opened.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если игрок входит в зону триггера
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true; // Устанавливаем флаг
            eButtonAction.SetActive(true); // Показываем подсказку "Нажмите E"
            Debug.Log("Player entered the trigger zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, если игрок выходит из зоны триггера
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false; // Сбрасываем флаг
            eButtonAction.SetActive(false); // Скрываем подсказку "Нажмите E"
            Debug.Log("Player exited the trigger zone.");
        }
    }

    public void OnSubmit()
    {
        // Получаем текст из TMP_InputField
        string input = inputField.text;

        // Проверяем, является ли ввод числом
        if (int.TryParse(input, out int number))
        {
            // Проверяем, больше ли число 5
            if (number > 5)
            {
                resultText.text = "Success! You entered: " + number;
                therminalPanel.SetActive(false); // Закрываем панель терминала
                Debug.Log("Valid number entered: " + number);
            }
            else
            {
                resultText.text = "Error: The number must be greater than 5.";
                Debug.Log("Invalid number: " + number);
            }
        }
        else
        {
            resultText.text = "Error: Please enter a valid number.";
            Debug.Log("Invalid input: " + input);
        }
    }
}
