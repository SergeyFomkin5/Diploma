using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTubeScript : MonoBehaviour
{
    [SerializeField] private Animator GreenCube;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SecondCube")
        {
            Debug.Log("enter");
            GreenCube.SetTrigger("GreenCube");
        }
    }
}
