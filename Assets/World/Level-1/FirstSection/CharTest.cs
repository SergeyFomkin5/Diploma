// CharTest.cs
using UnityEngine;

public class CharTest : MonoBehaviour
{
    [SerializeField] private Animator CharCube;
    public int isCorrectAnswer = 0;
    public bool isPlaced = false; // Добавляем флаг

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FourthCube"))
        {
            CharCube.SetTrigger("CharCube");
            isCorrectAnswer = 1;
            isPlaced = true; // Отмечаем размещение
        }
        else if (!other.CompareTag("Untagged"))
        {
            isCorrectAnswer = 2;
            isPlaced = true; // Отмечаем даже при ошибке
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FourthCube") || other.CompareTag("WrongCube"))
        {
            isCorrectAnswer = 0;
            isPlaced = false; // Сбрасываем флаг
        }
    }
}
