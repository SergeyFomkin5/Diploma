using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTest : MonoBehaviour
{
    [SerializeField] private Animator FloatCube;
    public int isCorrectAnswer = 0;
    public bool isPlaced = false; // ��������� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FifthCube"))
        {
            FloatCube.SetTrigger("FloatCube");
            isCorrectAnswer = 1;
            isPlaced = true; // �������� ����������
        }
        else if (!other.CompareTag("Untagged"))
        {
            isCorrectAnswer = 2;
            isPlaced = true; // �������� ���� ��� ������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FifthCube") || other.CompareTag("WrongCube"))
        {
            isCorrectAnswer = 0; // ���������� �������� ��� ������ ����
            isPlaced = false; // ���������� ����
        }
    }
}
