using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate_ThirdDoor_FirstPlate : MonoBehaviour
{
    public static int cubeOneCount = 0; // ���������� ���������� ��� ���� � �����
    public static int flowerCount = 0; // ���������� ���������� ��� ������
    public static int cubeTwoCount = 0; // ���������� ���������� ��� ���� � �����
    public static int cubeFourCount = 0; // ���������� ���������� ��� ���� � ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 1; // ������������� �������� ��� ���� � �����
        }
        else if (other.gameObject.name == "Flower")
        {
            flowerCount = 2; // ������������� �������� ��� ������
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeTwoCount = 2; // ������������� �������� ��� ���� � �����
        }
        else if (other.gameObject.name == "CubeWithFour")
        {
            cubeFourCount = 4; // ������������� �������� ��� ���� � ��������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 0; // ���������� �������� ��� ���� � �����
        }
        else if (other.gameObject.name == "Flower")
        {
            flowerCount = 0; // ���������� �������� ��� ������
        }
        else if (other.gameObject.name == "CubeWithTwo")
        {
            cubeTwoCount = 0; // ���������� �������� ��� ���� � �����
        }
        else if (other.gameObject.name == "CubeWithFour")
        {
            cubeFourCount = 0; // ���������� �������� ��� ���� � ��������
        }
    }
}
