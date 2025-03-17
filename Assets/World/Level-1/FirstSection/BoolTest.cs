using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolTest : MonoBehaviour
{
    [SerializeField] private Animator BoolCube;
    public int isCorrectAnswer = 0;
    public bool isPlaced = false; // Флаг размещения куба
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SecondCube"))
        {
            BoolCube.SetTrigger("BoolCube");
            isCorrectAnswer = 1;
            isPlaced = true;
        }
        else if (!other.CompareTag("Untagged"))
        {
            isCorrectAnswer = 2;
            isPlaced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SecondCube") || other.CompareTag("WrongCube"))
        {
            Debug.Log("Выход из триггера");
            isCorrectAnswer = 0; // Сбрасываем значение при выходе куба
            isPlaced = false;
        }
    }
}
