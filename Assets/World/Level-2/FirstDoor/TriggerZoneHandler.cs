using UnityEngine;

public class TriggerZoneHandler : MonoBehaviour
{
    public bool isPlayerInTrigger = false; // Флаг, находится ли игрок в зоне триггера

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true; // Устанавливаем флаг
            Debug.Log("Player entered the trigger zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false; // Сбрасываем флаг
            Debug.Log("Player exited the trigger zone.");
        }
    }
}
