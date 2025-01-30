using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate_FirstDoor_SecondPlate : MonoBehaviour
{
    public static int flowerCount = 0; // ���������� ���������� ��� ������
    public static int cubeTwoCount = 0; // ���������� ���������� ��� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 2; // ������������� �������� ��� ������
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeTwoCount = 1; // ������������� �������� ��� ����
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 0; // ���������� �������� ��� ������
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeTwoCount = 0; // ���������� �������� ��� ����
        }
    }
}
