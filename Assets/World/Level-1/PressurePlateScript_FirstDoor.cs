using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript_FirstDoor : MonoBehaviour
{
    public int flowerCount = 0;
    public int cubeOneCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Увеличиваем счетчики при входе объектов
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 2; // Устанавливаем значение для цветка
        }
        else if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 1; // Устанавливаем значение для куба
        }

        CheckOtherPlates();
    }

    private void OnTriggerExit(Collider other)
    {
        // Сбрасываем счетчики при выходе объектов
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 0; // Сбрасываем значение для цветка
        }
        else if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 0; // Сбрасываем значение для куба
        }

        CheckOtherPlates();
    }

    private void CheckOtherPlates()
    {
        // Находим все объекты с этим же скриптом в сцене
        PressurePlateScript_FirstDoor[] plates = FindObjectsOfType<PressurePlateScript_FirstDoor>();

        bool otherFlowerPresent = false;
        bool otherCubePresent = false;

        foreach (var plate in plates)
        {
            // Проверяем, есть ли на других плитках нужные объекты
            if (plate != this) // Не проверяем саму плитку
            {
                if (plate.flowerCount == 2)
                {
                    Debug.Log("На другой плитке есть цветок!");
                    otherFlowerPresent = true; // Устанавливаем флаг, если цветок найден
                }
                if (plate.cubeOneCount == 1)
                {
                    Debug.Log("На другой плитке есть куб!");
                    otherCubePresent = true; // Устанавливаем флаг, если куб найден
                }
            }
        }

        // Обновляем значения в зависимости от наличия объектов на других плитках
        if (otherFlowerPresent)
        {
            if (cubeOneCount != 1) // Проверяем, нужно ли обновлять значение
            {
                cubeOneCount = 1; // Если на другой плитке есть цветок, устанавливаем значение для куба
                Debug.Log($"Обновлено cubeOneCount: {cubeOneCount}");
            }
        }

        if (otherCubePresent)
        {
            if (flowerCount != 2) // Проверяем, нужно ли обновлять значение
            {
                flowerCount = 2; // Если на другой плитке есть куб, устанавливаем значение для цветка
                Debug.Log($"Обновлено flowerCount: {flowerCount}");
            }
        }

        // Дополнительно выводим текущее состояние плитки после обновления
        Debug.Log($"Текущее состояние плитки - Flower Count: {flowerCount}, Cube One Count: {cubeOneCount}");
    }
}
