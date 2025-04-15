using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate_SecondDoor_FirstPlate : MonoBehaviour
{
    public static int flowerCount = 0; // Глобальная переменная для цветка
    public static int cubeOneCount = 0; // Глобальная переменная для куба

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 2; // Устанавливаем значение для цветка
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeOneCount = 2; // Устанавливаем значение для куба
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 0; // Сбрасываем значение для цветка
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeOneCount = 0; // Сбрасываем значение для куба
        }
    }
}
