// CharTest.cs
using UnityEngine;

public class CharTest : MonoBehaviour
{
    [SerializeField] private Animator CharCube;
    public int isCorrectAnswer = 0;
    public bool isPlaced = false; // ��������� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FourthCube"))
        {
            CharCube.SetTrigger("CharCube");
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
        if (other.CompareTag("FourthCube") || other.CompareTag("WrongCube"))
        {
            isCorrectAnswer = 0;
            isPlaced = false; // ���������� ����
        }
    }
}
