using System.Collections;
using UnityEngine;

public class FailAnswer : MonoBehaviour
{
    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;

    private GreenTubeScript greenTubeScript;
    private RedTubeScript redTubeScript;

    private Coroutine messageCoroutine; // Хранит ссылку на корутину

    private void Awake()
    {
        greenTubeScript = FindObjectOfType<GreenTubeScript>();
        redTubeScript = FindObjectOfType<RedTubeScript>();

        if (greenTubeScript == null)
            Debug.LogError("GreenTubeScript не найден в сцене.");

        if (redTubeScript == null)
            Debug.LogError("RedTubeScript не найден в сцене.");
    }

    private void Update()
    {
        // Проверяем, инициализированы ли компоненты перед использованием
        if (greenTubeScript != null && redTubeScript != null)
        {
            int greenAnswer = greenTubeScript.isCorrectAnswer;
            int redAnswer = redTubeScript.isCorrectAnswer;

            // Используем switch для проверки условий активации сообщения
            switch ((greenAnswer, redAnswer))
            {
                case (2, 2):
                    ShowFailMessage();
                    break;
                case (1, 1): // Пример условия для поздравительного сообщения
                    ShowCongratulationslMessage();
                    break;
                default:
                    if (messageCoroutine != null) // Если сообщение активно
                    {
                        HideFailMessage();
                        HideCongratulationsMessage(); // Убедитесь, что это тоже скрывается
                    }
                    break;
            }
        }
    }

    private void ShowFailMessage()
    {
        if (messageCoroutine == null) // Проверяем, активна ли корутина
        {
            failMessage.SetActive(true);
            Debug.Log("Сообщение активно");
            messageCoroutine = StartCoroutine(ShowFailMessageForSeconds(5f));
        }
    }

    private void HideFailMessage()
    {
        if (messageCoroutine != null) // Проверяем, активна ли корутина перед остановкой
        {
            StopCoroutine(messageCoroutine); // Останавливаем корутину
            messageCoroutine = null; // Сбрасываем ссылку на корутину
        }

        failMessage.SetActive(false);
        Debug.Log("Сообщение деактивировано");

        // Сброс значения isCorrectAnswer только если это необходимо
        greenTubeScript.isCorrectAnswer = 0;
    }

    private IEnumerator ShowFailMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideFailMessage(); // Скрываем сообщение после ожидания
    }

    private IEnumerator ShowCongratulationsMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideCongratulationsMessage(); // Скрываем сообщение после ожидания
    }

    private void ShowCongratulationslMessage()
    {
        if (messageCoroutine == null) // Проверяем, активна ли корутина
        {
            congratulationsMessage.SetActive(true);
            Debug.Log("Поздравительное сообщение активно");
            messageCoroutine = StartCoroutine(ShowCongratulationsMessageForSeconds(5f));
        }
    }

    private void HideCongratulationsMessage()
    {
        if (messageCoroutine != null) // Проверяем, активна ли корутина перед остановкой
        {
            StopCoroutine(messageCoroutine); // Останавливаем корутину
            messageCoroutine = null; // Сбрасываем ссылку на корутину
        }

        congratulationsMessage.SetActive(false);
        Debug.Log("Поздравительное сообщение деактивировано");

        // Сброс значения isCorrectAnswer только если это необходимо
        greenTubeScript.isCorrectAnswer = 0;
    }
}
