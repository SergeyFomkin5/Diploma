using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalList : MonoBehaviour
{
    public Level_2_OpenTerminal Level_2_Terminal;

    public void Awake()
    {
        Level_2_Terminal = GetComponent<Level_2_OpenTerminal>();
    }
}
