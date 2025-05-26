using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTubeScript : MonoBehaviour
{
    [SerializeField] private Animator RedCube;
    public int isCorrectAnswer = 0;

    private void Start()
    {
        isCorrectAnswer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FirstCube")
        {
            Debug.Log("enter");
            RedCube.SetTrigger("RedCube");
            isCorrectAnswer = 1;
        } else
        {
            isCorrectAnswer = 2;
        }
        
    }
}
