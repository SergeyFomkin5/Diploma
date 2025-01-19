using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTubeScript : MonoBehaviour
{
    [SerializeField] private Animator RedCube;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FirstCube")
        {
            Debug.Log("enter");
            RedCube.SetTrigger("RedCube");
        }
    }
}
