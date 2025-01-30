using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTest : MonoBehaviour
{
    [SerializeField] private Animator FloatCube;
    public int isCorrectAnswer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FifthCube")
        {
            Debug.Log("enter");
            FloatCube.SetTrigger("FloatCube");
            isCorrectAnswer = 1;
        }
        else
        {
            isCorrectAnswer = 2;
        }
    }
}
