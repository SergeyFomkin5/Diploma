using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckInputNumber : MonoBehaviour
{
    public TMP_InputField inputField; // Reference to the InputField
    public TMP_Text resultText; // Reference to the Text for displaying results
    public GameObject therminalPanel; // Panel for terminal interaction
    public GameObject eButtonAction; // Button action prompt
    public GameObject therminalTriggerZone; // Trigger zone for terminal

    private Collider triggerZoneCollider; // Reference to the BoxCollider of therminalTriggerZone

    void Start()
    {
        // Получаем Collider из therminalTriggerZone
        if (therminalTriggerZone != null)
        {
            triggerZoneCollider = therminalTriggerZone.GetComponent<Collider>();
        }
        else
        {
            Debug.LogError("Therminal Trigger Zone is not assigned!");
        }
    }

    void Update()
    {
        // Проверяем, нажата ли клавиша Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnSubmit();
        }

        // Проверяем, нажата ли клавиша E и активен ли eButtonAction
        if (Input.GetKeyDown(KeyCode.E) && eButtonAction.activeSelf)
        {
            therminalPanel.SetActive(true);
            eButtonAction.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Проверяем, находится ли игрок в зоне триггера therminalTriggerZone
        if (triggerZoneCollider != null && other.gameObject.CompareTag("Player") && !therminalPanel.activeSelf)
        {
            eButtonAction.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Скрываем подсказку при выходе игрока из зоны триггера
        if (triggerZoneCollider != null && other.gameObject.CompareTag("Player"))
        {
            eButtonAction.SetActive(false);
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
                therminalPanel.SetActive(false);
            }
            else
            {
                resultText.text = "Error: The number must be greater than 5.";
            }
        }
        else
        {
            resultText.text = "Error: Please enter a valid number.";
        }
    }
}
