using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTest : MonoBehaviour
{
    [SerializeField] private Animator CharCube;
    public int isCorrectAnswer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FourthCube")
        {
            Debug.Log("enter");
            CharCube.SetTrigger("CharCube");
            isCorrectAnswer = 1;
        }
        else
        {
            isCorrectAnswer = 2;
        }
    }
}
