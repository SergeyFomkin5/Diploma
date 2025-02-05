using UnityEngine;

public class TriggerZoneHandler : MonoBehaviour
{
    public bool isPlayerInTrigger = false; // ����, ��������� �� ����� � ���� ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true; // ������������� ����
            Debug.Log("Player entered the trigger zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false; // ���������� ����
            Debug.Log("Player exited the trigger zone.");
        }
    }
}
