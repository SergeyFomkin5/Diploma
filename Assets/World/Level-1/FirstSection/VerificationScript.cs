using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificationScript : MonoBehaviour
{
    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;

    private cubesTestsScript cubesTests; // ������ �� cubesTestsScript

    private Coroutine messageCoroutine; // ������ ������ �� ��������

    private void Awake()
    {
        // �������� ������ �� cubesTestsScript
        cubesTests = FindObjectOfType<cubesTestsScript>();
    }

    private void Update()
    {
        if (cubesTests != null)
        {
            // ������� ������ ��� �������� �������
            int[] answers = new int[5];
            answers[0] = cubesTests.intCube.isCorrectAnswer;
            answers[1] = cubesTests.boolCube.isCorrectAnswer; // ����������� bool � int
            answers[2] = cubesTests.stringCube.isCorrectAnswer; // ��������������, ��� ��� int
            answers[3] = cubesTests.charCube.isCorrectAnswer; // ��������������, ��� ��� int
            answers[4] = cubesTests.floatCube.isCorrectAnswer; // ��������������, ��� ��� int

            bool hasError = false;
            bool allCorrect = true;

            // ��������� ������� ��� ���������
            foreach (int answer in answers)
            {
                if (answer == 2)
                {
                    hasError = true; // ���� ���� �� ���� ����� ����� 2, ������������� ���� ������
                }
                if (answer != 1)
                {
                    allCorrect = false; // ���� ���� �� ���� ����� �� ����� 1, ������������� ���� �� false
                }
            }

            if (hasError)
            {
                ShowFailMessage(); // ���������� ��������� �� ������
            }
            else if (allCorrect)
            {
                ShowCongratulationslMessage(); // ���������� ��������������� ���������
            }
            else
            {
                if (messageCoroutine != null)
                {
                    HideFailMessage();
                    HideCongratulationsMessage();
                }
            }
        }
    }

    private void ShowFailMessage()
    {
        if (messageCoroutine == null)
        {
            failMessage.SetActive(true);
            Debug.Log("��������� �� ������ �������");
            messageCoroutine = StartCoroutine(ShowFailMessageForSeconds(5f));
        }
    }

    private void HideFailMessage()
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
            messageCoroutine = null;
        }

        failMessage.SetActive(false);
        Debug.Log("��������� �� ������ ��������������");

        // ����� �������� isCorrectAnswer ������ ���� ��� ����������
        cubesTests.intCube.isCorrectAnswer = 0; // ���� ����� �������� ��������
    }

    private IEnumerator ShowFailMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideFailMessage();
    }

    private void ShowCongratulationslMessage()
    {
        if (messageCoroutine == null)
        {
            congratulationsMessage.SetActive(true);
            Debug.Log("��������������� ��������� �������");
            messageCoroutine = StartCoroutine(ShowCongratulationsMessageForSeconds(5f));
        }
    }

    private void HideCongratulationsMessage()
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
            messageCoroutine = null;
        }

        congratulationsMessage.SetActive(false);
        Debug.Log("��������������� ��������� ��������������");

        // ����� �������� isCorrectAnswer ������ ���� ��� ����������
        cubesTests.intCube.isCorrectAnswer = 0; // ���� ����� �������� ��������
    }

    private IEnumerator ShowCongratulationsMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideCongratulationsMessage();
    }
}
