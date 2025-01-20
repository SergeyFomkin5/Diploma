using System.Collections;
using UnityEngine;

public class FailAnswer : MonoBehaviour
{
    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;

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
            int greenAnswer = greenTubeScript.isCorrectAnswer;
            int redAnswer = redTubeScript.isCorrectAnswer;

            // ���������� switch ��� �������� ������� ��������� ���������
            switch ((greenAnswer, redAnswer))
            {
                case (2, 2):
                    ShowFailMessage();
                    break;
                case (1, 1): // ������ ������� ��� ���������������� ���������
                    ShowCongratulationslMessage();
                    break;
                default:
                    if (messageCoroutine != null) // ���� ��������� �������
                    {
                        HideFailMessage();
                        HideCongratulationsMessage(); // ���������, ��� ��� ���� ����������
                    }
                    break;
            }
        }
    }

    private void ShowFailMessage()
    {
        if (messageCoroutine == null) // ���������, ������� �� ��������
        {
            failMessage.SetActive(true);
            Debug.Log("��������� �������");
            messageCoroutine = StartCoroutine(ShowFailMessageForSeconds(5f));
        }
    }

    private void HideFailMessage()
    {
        if (messageCoroutine != null) // ���������, ������� �� �������� ����� ����������
        {
            StopCoroutine(messageCoroutine); // ������������� ��������
            messageCoroutine = null; // ���������� ������ �� ��������
        }

        failMessage.SetActive(false);
        Debug.Log("��������� ��������������");

        // ����� �������� isCorrectAnswer ������ ���� ��� ����������
        greenTubeScript.isCorrectAnswer = 0;
    }

    private IEnumerator ShowFailMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideFailMessage(); // �������� ��������� ����� ��������
    }

    private IEnumerator ShowCongratulationsMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideCongratulationsMessage(); // �������� ��������� ����� ��������
    }

    private void ShowCongratulationslMessage()
    {
        if (messageCoroutine == null) // ���������, ������� �� ��������
        {
            congratulationsMessage.SetActive(true);
            Debug.Log("��������������� ��������� �������");
            messageCoroutine = StartCoroutine(ShowCongratulationsMessageForSeconds(5f));
        }
    }

    private void HideCongratulationsMessage()
    {
        if (messageCoroutine != null) // ���������, ������� �� �������� ����� ����������
        {
            StopCoroutine(messageCoroutine); // ������������� ��������
            messageCoroutine = null; // ���������� ������ �� ��������
        }

        congratulationsMessage.SetActive(false);
        Debug.Log("��������������� ��������� ��������������");

        // ����� �������� isCorrectAnswer ������ ���� ��� ����������
        greenTubeScript.isCorrectAnswer = 0;
    }
}
