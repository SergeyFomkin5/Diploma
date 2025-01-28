using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolTest : MonoBehaviour
{
    [SerializeField] private Animator BoolCube;
    public int isCorrectAnswer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SecondCube")
        {
            Debug.Log("enter");
            BoolCube.SetTrigger("BoolCube");
            isCorrectAnswer = 1;
        }
        else
        {
            isCorrectAnswer = 2;
        }
    }
}
