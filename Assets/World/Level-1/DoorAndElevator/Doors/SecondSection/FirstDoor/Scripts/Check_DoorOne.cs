using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_DoorOne : MonoBehaviour
{
    [SerializeField] private Animator firstDoorAnimation;

    void Update()
    {
        CheckDoors();
    }

    private void CheckDoors()
    {
        bool isFlowerOnFirstPlate = PressurePlate_FirstDoor.flowerCount == 2;
        bool isCubeOnFirstPlate = PressurePlate_FirstDoor.cubeOneCount == 1;

        bool isFlowerOnSecondPlate = PressurePlate_FirstDoor_SecondPlate.flowerCount == 2;
        bool isCubeOnSecondPlate = PressurePlate_FirstDoor_SecondPlate.cubeOneCount == 1;

        // Проверяем, находится ли цветок на одной плитке, а куб на другой
        if ((isFlowerOnFirstPlate && isCubeOnSecondPlate) || (isCubeOnFirstPlate && isFlowerOnSecondPlate) ||
            (isFlowerOnFirstPlate && !isCubeOnFirstPlate && isCubeOnSecondPlate) ||
            (isFlowerOnSecondPlate && isCubeOnFirstPlate && !isCubeOnSecondPlate))
        {
            firstDoorAnimation.SetTrigger("DoorOne");
            Debug.Log("Дверь открыта!");
        }
    }
}
