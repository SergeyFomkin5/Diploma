using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificationScript : MonoBehaviour
{
    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;

    private cubesTestsScript cubesTests; // Ссылка на cubesTestsScript

    private Coroutine messageCoroutine; // Хранит ссылку на корутину

    private void Awake()
    {
        // Получаем ссылку на cubesTestsScript
        cubesTests = FindObjectOfType<cubesTestsScript>();
    }

    private void Update()
    {
        if (cubesTests != null)
        {
            // Создаем массив для хранения ответов
            int[] answers = new int[5];
            answers[0] = cubesTests.intCube.isCorrectAnswer;
            answers[1] = cubesTests.boolCube.isCorrectAnswer; // Преобразуем bool в int
            answers[2] = cubesTests.stringCube.isCorrectAnswer; // Предполагается, что это int
            answers[3] = cubesTests.charCube.isCorrectAnswer; // Предполагается, что это int
            answers[4] = cubesTests.floatCube.isCorrectAnswer; // Предполагается, что это int

            bool hasError = false;
            bool allCorrect = true;

            // Проверяем условия для сообщений
            foreach (int answer in answers)
            {
                if (answer == 2)
                {
                    hasError = true; // Если хотя бы один ответ равен 2, устанавливаем флаг ошибки
                }
                if (answer != 1)
                {
                    allCorrect = false; // Если хотя бы один ответ не равен 1, устанавливаем флаг на false
                }
            }

            if (hasError)
            {
                ShowFailMessage(); // Показываем сообщение об ошибке
            }
            else if (allCorrect)
            {
                ShowCongratulationslMessage(); // Показываем поздравительное сообщение
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
            Debug.Log("Сообщение об ошибке активно");
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
        Debug.Log("Сообщение об ошибке деактивировано");

        // Сброс значения isCorrectAnswer только если это необходимо
        cubesTests.intCube.isCorrectAnswer = 0; // Если нужно сбросить значение
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
            Debug.Log("Поздравительное сообщение активно");
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
        Debug.Log("Поздравительное сообщение деактивировано");

        // Сброс значения isCorrectAnswer только если это необходимо
        cubesTests.intCube.isCorrectAnswer = 0; // Если нужно сбросить значение
    }

    private IEnumerator ShowCongratulationsMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideCongratulationsMessage();
    }
}
