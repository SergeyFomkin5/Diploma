using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeScript : MonoBehaviour
{
    [SerializeField] private Animator gate;

    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;

    private Coroutine messageCoroutine; // ������ ������ �� ��������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == true && other.gameObject.name == "Key")
        {
            gate.SetTrigger("FinalGateOpen");
            ShowCongratulationslMessage();
        } else
        {
            if (messageCoroutine != null)
            {
                HideCongratulationsMessage();
            }
        }
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
    }

    private IEnumerator ShowCongratulationsMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideCongratulationsMessage();
    }
}
