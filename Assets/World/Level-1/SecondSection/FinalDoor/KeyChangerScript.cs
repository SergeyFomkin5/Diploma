using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChangerScript : MonoBehaviour
{
    public KeyScript key;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Key")
        {
            key.isKey = true;
        }
    }
}
