using System.Collections;
using UnityEngine;

public class FailAnswer : MonoBehaviour
{
    [SerializeField] private GameObject message;

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
            // Проверяем условия активации сообщения
            if (greenTubeScript.isCorrectAnswer == 2 && redTubeScript.isCorrectAnswer == 2)
            {
                ShowMessage();
            }
            else if (messageCoroutine != null) // Если сообщение активно
            {
                HideMessage();
            }
        }
    }

    private void ShowMessage()
    {
        if (messageCoroutine == null) // Проверяем, активна ли корутина
        {
            message.SetActive(true);
            Debug.Log("Сообщение активно");
            messageCoroutine = StartCoroutine(ShowMessageForSeconds(5f));
        }
    }

    private void HideMessage()
    {
        if (messageCoroutine != null) // Проверяем, активна ли корутина перед остановкой
        {
            StopCoroutine(messageCoroutine); // Останавливаем корутину
            messageCoroutine = null; // Сбрасываем ссылку на корутину
        }

        message.SetActive(false);
        Debug.Log("Сообщение деактивировано");

        // Сброс значения isCorrectAnswer только если это необходимо
        greenTubeScript.isCorrectAnswer = 0;
    }

    private IEnumerator ShowMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideMessage(); // Скрываем сообщение после ожидания
    }
}
