using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntTest : MonoBehaviour
{
    [SerializeField] private Animator IntCube;
    public int isCorrectAnswer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FirstCube")
        {
            Debug.Log("enter");
            IntCube.SetTrigger("IntCube");
            isCorrectAnswer = 1;
        }
        else
        {
            isCorrectAnswer = 2;
        }
    }
}
