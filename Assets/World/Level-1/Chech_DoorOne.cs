using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Chech_DoorOne : MonoBehaviour
{
    private PressurePlateScript_FirstDoor presurePlates;

    [SerializeField] private GameObject firstDoorAnimation;
    // Start is called before the first frame update
    void Start()
    {
        presurePlates = FindAnyObjectByType<PressurePlateScript_FirstDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFirstDoor();
    }

    private void CheckFirstDoor()
    {
        var checkSum = presurePlates.cubeOneCount + presurePlates.flowerCount;

        if (checkSum == 3)
        {
            firstDoorAnimation.SetActive(false);
        }
    }
}
