using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript_FirstDoor : MonoBehaviour
{
    public int flowerCount = 0;
    public int cubeOneCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        // ����������� �������� ��� ����� ��������
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 2; // ������������� �������� ��� ������
        }
        else if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 1; // ������������� �������� ��� ����
        }

        CheckOtherPlates();
    }

    private void OnTriggerExit(Collider other)
    {
        // ���������� �������� ��� ������ ��������
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 0; // ���������� �������� ��� ������
        }
        else if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 0; // ���������� �������� ��� ����
        }

        CheckOtherPlates();
    }

    private void CheckOtherPlates()
    {
        // ������� ��� ������� � ���� �� �������� � �����
        PressurePlateScript_FirstDoor[] plates = FindObjectsOfType<PressurePlateScript_FirstDoor>();

        bool otherFlowerPresent = false;
        bool otherCubePresent = false;

        foreach (var plate in plates)
        {
            // ���������, ���� �� �� ������ ������� ������ �������
            if (plate != this) // �� ��������� ���� ������
            {
                if (plate.flowerCount == 2)
                {
                    Debug.Log("�� ������ ������ ���� ������!");
                    otherFlowerPresent = true; // ������������� ����, ���� ������ ������
                }
                if (plate.cubeOneCount == 1)
                {
                    Debug.Log("�� ������ ������ ���� ���!");
                    otherCubePresent = true; // ������������� ����, ���� ��� ������
                }
            }
        }

        // ��������� �������� � ����������� �� ������� �������� �� ������ �������
        if (otherFlowerPresent)
        {
            if (cubeOneCount != 1) // ���������, ����� �� ��������� ��������
            {
                cubeOneCount = 1; // ���� �� ������ ������ ���� ������, ������������� �������� ��� ����
                Debug.Log($"��������� cubeOneCount: {cubeOneCount}");
            }
        }

        if (otherCubePresent)
        {
            if (flowerCount != 2) // ���������, ����� �� ��������� ��������
            {
                flowerCount = 2; // ���� �� ������ ������ ���� ���, ������������� �������� ��� ������
                Debug.Log($"��������� flowerCount: {flowerCount}");
            }
        }

        // ������������� ������� ������� ��������� ������ ����� ����������
        Debug.Log($"������� ��������� ������ - Flower Count: {flowerCount}, Cube One Count: {cubeOneCount}");
    }
}
