using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate_ThirdDoor_FirstPlate : MonoBehaviour
{
    public static int cubeOneCount = 0; // Глобальная переменная для куба с одним
    public static int flowerCount = 0; // Глобальная переменная для цветка
    public static int cubeTwoCount = 0; // Глобальная переменная для куба с двумя
    public static int cubeFourCount = 0; // Глобальная переменная для куба с четырьмя

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 1; // Устанавливаем значение для куба с одним
        }
        else if (other.gameObject.name == "Flower")
        {
            flowerCount = 2; // Устанавливаем значение для цветка
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeTwoCount = 2; // Устанавливаем значение для куба с двумя
        }
        else if (other.gameObject.name == "CubeWithFour")
        {
            cubeFourCount = 4; // Устанавливаем значение для куба с четырьмя
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 0; // Сбрасываем значение для куба с одним
        }
        else if (other.gameObject.name == "Flower")
        {
            flowerCount = 0; // Сбрасываем значение для цветка
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeTwoCount = 0; // Сбрасываем значение для куба с двумя
        }
        else if (other.gameObject.name == "CubeWithFour")
        {
            cubeFourCount = 0; // Сбрасываем значение для куба с четырьмя
        }
    }
}
