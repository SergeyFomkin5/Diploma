using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSecondDoor : MonoBehaviour
{
    [SerializeField] private Animator secondDoorAnimation;

    void Update()
    {
        CheckDoors();
    }

    private void CheckDoors()
    {
        bool isFlowerOnFirstPlate = PressurePlate_SecondDoor_FirstPlate.flowerCount == 2;
        bool isCubeOnFirstPlate = PressurePlate_SecondDoor_FirstPlate.cubeOneCount == 2;

        bool isFlowerOnSecondPlate = PressurePlate_SecondDoor_SecondPlate.flowerCount == 2;
        bool isCubeOnSecondPlate = PressurePlate_SecondDoor_SecondPlate.cubeTwoCount == 2;

        // Проверяем, находится ли цветок на одной плитке, а куб на другой
        if ((isFlowerOnFirstPlate && isCubeOnSecondPlate) || (isCubeOnFirstPlate && isFlowerOnSecondPlate))
        {
            secondDoorAnimation.SetTrigger("DoorTwo");
            Debug.Log("Вторая дверь открыта!");
        }
    }
}
