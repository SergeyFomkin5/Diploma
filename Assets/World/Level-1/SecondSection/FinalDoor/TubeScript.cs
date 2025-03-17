using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeScript : MonoBehaviour
{
    [SerializeField] private Animator gate;
    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;
    [SerializeField] public KeyScript key;

    private Coroutine messageCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("������ ����� � �������: " + other.gameObject.name);
        Debug.Log("isKey: " + key.isKey);

        if (key.isKey && other.gameObject.name == "Key")
        {
            Debug.Log("������� ���������: ���� ������");
            gate.SetTrigger("FinalGateOpen");
            ShowCongratulationsMessage();
        }
        else
        {
            Debug.Log("������� �� ���������: ���� �� ������");
            ShowFailMessage();
        }
    }

    private void ShowCongratulationsMessage()
    {
        if (!congratulationsMessage.activeSelf)
        {
            Debug.Log("����� ���������������� ���������");
            HideAllMessages();
            congratulationsMessage.SetActive(true);
            messageCoroutine = StartCoroutine(HideAfterDelay(5f));
        }
    }

    private void ShowFailMessage()
    {
        if (!failMessage.activeSelf)
        {
            Debug.Log("����� ��������� �� ������");
            HideAllMessages();
            failMessage.SetActive(true);
            messageCoroutine = StartCoroutine(HideAfterDelay(5f));
        }
    }

    private void HideAllMessages()
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
            messageCoroutine = null;
        }
        failMessage.SetActive(false);
        congratulationsMessage.SetActive(false);
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        Debug.Log("�������� ��������");
        yield return new WaitForSeconds(delay);
        Debug.Log("�������� ���������");
        HideAllMessages();
    }
}