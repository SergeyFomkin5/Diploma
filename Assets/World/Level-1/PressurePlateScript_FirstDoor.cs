using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript_FirstDoor : MonoBehaviour
{
    public int flowerCount = 0;
    public int cubeOneCount = 0;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Flower")
        {
            flowerCount = 2;
        }
        if (other.gameObject.name == "CubeWithOne")
        {
            cubeOneCount = 1;
        }
    }
}
