using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTest : MonoBehaviour
{
    [SerializeField] private Animator StringCube;
    public int isCorrectAnswer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThirdCube")
        {
            Debug.Log("enter");
            StringCube.SetTrigger("StringCube");
            isCorrectAnswer = 1;
        }
        else
        {
            isCorrectAnswer = 2;
        }
    }
}
