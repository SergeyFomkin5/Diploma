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
            Debug.LogError("intCube не найден на сцене");
        }
        if (boolCube == null)
        {
            Debug.LogError("boolCube не найден на сцене");
        }
        if (stringCube == null)
        {
            Debug.LogError("stringCube не найден на сцене");
        }
        if (charCube == null)
        {
            Debug.LogError("charCube не найден на сцене");
        }
        if (floatCube == null)
        {
            Debug.LogError("floatCube не найден на сцене");
        }

    }
}
