using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate_SecondDoor_FirstPlate : MonoBehaviour
{
    public static int flowerCount = 0; // ���������� ���������� ��� ������
    public static int cubeOneCount = 0; // ���������� ���������� ��� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 2; // ������������� �������� ��� ������
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeOneCount = 2; // ������������� �������� ��� ����
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
            cubeOneCount = 0; // ���������� �������� ��� ����
        }
    }
}
