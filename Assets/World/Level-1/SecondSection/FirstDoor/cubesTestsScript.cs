using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubesTestsScript : MonoBehaviour
{
    public IntTest intCube;
    public BoolTest boolCube;
    public StringTest stringCube;
    public CharTest charCube;
    public FloatTest floatCube;

    private void Awake()
    {
        intCube = FindObjectOfType<IntTest>();
        boolCube = FindObjectOfType<BoolTest>();
        stringCube = FindObjectOfType<StringTest>();
        charCube = FindObjectOfType<CharTest>();
        floatCube = FindObjectOfType<FloatTest>();

        if (intCube == null)
        {
            Debug.LogError("intCube �� ������ �� �����");
        }
        if (boolCube == null)
        {
            Debug.LogError("boolCube �� ������ �� �����");
        }
        if (stringCube == null)
        {
            Debug.LogError("stringCube �� ������ �� �����");
        }
        if (charCube == null)
        {
            Debug.LogError("charCube �� ������ �� �����");
        }
        if (floatCube == null)
        {
            Debug.LogError("floatCube �� ������ �� �����");
        }

    }
}
