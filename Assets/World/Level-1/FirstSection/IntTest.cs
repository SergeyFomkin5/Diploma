using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntTest : MonoBehaviour
{
    [SerializeField] private Animator IntCube;
    public int isCorrectAnswer = 0;
    public bool isPlaced = false; // ��������� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirstCube"))
        {
            IntCube.SetTrigger("IntCube");
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
        if (other.CompareTag("FirstCube") || other.CompareTag("WrongCube"))
        {
            isCorrectAnswer = 0; // ���������� �������� ��� ������ ����
            isPlaced = false;
        }
    }
}
