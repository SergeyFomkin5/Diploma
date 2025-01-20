using System.Collections;
using UnityEngine;

public class FailAnswer : MonoBehaviour
{
    [SerializeField] private GameObject message;

    private GreenTubeScript greenTubeScript;
    private RedTubeScript redTubeScript;

    private Coroutine messageCoroutine; // ������ ������ �� ��������

    private void Awake()
    {
        greenTubeScript = FindObjectOfType<GreenTubeScript>();
        redTubeScript = FindObjectOfType<RedTubeScript>();

        if (greenTubeScript == null)
            Debug.LogError("GreenTubeScript �� ������ � �����.");

        if (redTubeScript == null)
            Debug.LogError("RedTubeScript �� ������ � �����.");
    }

    private void Update()
    {
        // ���������, ���������������� �� ���������� ����� ��������������
        if (greenTubeScript != null && redTubeScript != null)
        {
            // ��������� ������� ��������� ���������
            if (greenTubeScript.isCorrectAnswer == 2 && redTubeScript.isCorrectAnswer == 2)
            {
                ShowMessage();
            }
            else if (messageCoroutine != null) // ���� ��������� �������
            {
                HideMessage();
            }
        }
    }

    private void ShowMessage()
    {
        if (messageCoroutine == null) // ���������, ������� �� ��������
        {
            message.SetActive(true);
            Debug.Log("��������� �������");
            messageCoroutine = StartCoroutine(ShowMessageForSeconds(5f));
        }
    }

    private void HideMessage()
    {
        if (messageCoroutine != null) // ���������, ������� �� �������� ����� ����������
        {
            StopCoroutine(messageCoroutine); // ������������� ��������
            messageCoroutine = null; // ���������� ������ �� ��������
        }

        message.SetActive(false);
        Debug.Log("��������� ��������������");

        // ����� �������� isCorrectAnswer ������ ���� ��� ����������
        greenTubeScript.isCorrectAnswer = 0;
    }

    private IEnumerator ShowMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideMessage(); // �������� ��������� ����� ��������
    }
}
