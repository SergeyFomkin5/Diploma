using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntTest : MonoBehaviour
{
    [SerializeField] private Animator IntCube;
    public int isCorrectAnswer = 0;
    public bool isPlaced = false; // Добавляем флаг
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirstCube"))
        {
            IntCube.SetTrigger("IntCube");
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
        if (other.CompareTag("FirstCube") || other.CompareTag("WrongCube"))
        {
            isCorrectAnswer = 0; // Сбрасываем значение при выходе куба
            isPlaced = false;
        }
    }
}
