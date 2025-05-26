using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTubeScript : MonoBehaviour
{
    [SerializeField] private Animator GreenCube;
    public int isCorrectAnswer = 0;

    private void Start()
    {
        isCorrectAnswer = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SecondCube")
        {
            Debug.Log("enter");
            GreenCube.SetTrigger("GreenCube");
            isCorrectAnswer = 1;
        } else
        {
            isCorrectAnswer = 2;
        }
    }
}
