using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckInputNumber : MonoBehaviour
{
    public TMP_InputField inputField; // ���� ��� ����� �����
    public TMP_Text resultText; // ����� ��� ����������� ����������
    public GameObject therminalPanel; // ������ ���������
    public GameObject eButtonAction; // ��������� "������� E"
    public Collider therminalTriggerZone; // ���� �������� ���������

    private bool isPlayerInTrigger = false; // ����, ��������� �� ����� � ���� ��������

    void Update()
    {
        // ���������, ������ �� ������� Enter (��� �������� �����)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnSubmit();
        }

        // ���������, ������ �� ������� E � ����� ��������� � ���� ��������
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInTrigger)
        {
            therminalPanel.SetActive(true); // ��������� ������ ���������
            eButtonAction.SetActive(false); // �������� ��������� "������� E"
            Debug.Log("Terminal panel opened.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ���� ����� ������ � ���� ��������
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true; // ������������� ����
            eButtonAction.SetActive(true); // ���������� ��������� "������� E"
            Debug.Log("Player entered the trigger zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���������, ���� ����� ������� �� ���� ��������
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false; // ���������� ����
            eButtonAction.SetActive(false); // �������� ��������� "������� E"
            Debug.Log("Player exited the trigger zone.");
        }
    }

    public void OnSubmit()
    {
        // �������� ����� �� TMP_InputField
        string input = inputField.text;

        // ���������, �������� �� ���� ������
        if (int.TryParse(input, out int number))
        {
            // ���������, ������ �� ����� 5
            if (number > 5)
            {
                resultText.text = "Success! You entered: " + number;
                therminalPanel.SetActive(false); // ��������� ������ ���������
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
