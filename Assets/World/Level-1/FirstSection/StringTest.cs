// StringTest.cs
using UnityEngine;

public class StringTest : MonoBehaviour
{
    [SerializeField] private Animator StringCube;
    public int isCorrectAnswer = 0;
    public bool isPlaced = false; // ‘лаг размещени€ куба

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThirdCube"))
        {
            StringCube.SetTrigger("StringCube");
            isCorrectAnswer = 1;
            isPlaced = true;
        }
        else if (!other.CompareTag("Untagged"))
        {
            isCorrectAnswer = 2;
            isPlaced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ThirdCube") || other.CompareTag("WrongCube"))
        {
            isCorrectAnswer = 0;
            isPlaced = false; // —брасываем флаг при выходе
        }
    }
}
