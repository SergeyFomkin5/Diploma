using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckThirdDoor : MonoBehaviour
{
    [SerializeField] private Animator thirdDoorAnimation;

    void Update()
    {
        CheckDoors();
    }

    private void CheckDoors()
    {
        bool isCubeOneOnFirstPlate = PressurePlate_ThirdDoor_FirstPlate.cubeOneCount == 1;
        bool isFlowerOnFirstPlate = PressurePlate_ThirdDoor_FirstPlate.flowerCount == 2;
        bool isCubeTwoOnFirstPlate = PressurePlate_ThirdDoor_FirstPlate.cubeTwoCount == 2;
        bool isCubeFourOnFirstPlate = PressurePlate_ThirdDoor_FirstPlate.cubeFourCount == 4;

        bool isCubeOneOnSecondPlate = PressurePlate_ThirdDoor_SecondPlate.cubeOneCount == 1;
        bool isFlowerOnSecondPlate = PressurePlate_ThirdDoor_SecondPlate.flowerCount == 2;
        bool isCubeTwoOnSecondPlate = PressurePlate_ThirdDoor_SecondPlate.cubeTwoCount == 2;
        bool isCubeFourOnSecondPlate = PressurePlate_ThirdDoor_SecondPlate.cubeFourCount == 4;

        // Проверяем, находятся ли Flower, CubeWithTwo и CubeWithFour вместе на одной плитке,
        // а CubeWithOne на другой плитке.
        bool threeObjectsOnFirstPlate = isFlowerOnFirstPlate && isCubeTwoOnFirstPlate && isCubeFourOnFirstPlate;
        bool threeObjectsOnSecondPlate = isFlowerOnSecondPlate && isCubeTwoOnSecondPlate && isCubeFourOnSecondPlate;

        if ((threeObjectsOnFirstPlate && !isCubeOneOnFirstPlate && isCubeOneOnSecondPlate) ||
            (threeObjectsOnSecondPlate && !isCubeOneOnSecondPlate && isCubeOneOnFirstPlate))
        {
            thirdDoorAnimation.SetTrigger("DoorThree");
            Debug.Log("Третья дверь открыта!");
        }

        // Если не выполнены условия, можно добавить дополнительные действия, если это необходимо.
    }
}
