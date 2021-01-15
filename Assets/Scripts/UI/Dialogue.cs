using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue
{
    public string name;
    //textarea(min_lines, max_lines)
    [TextArea(3, 10)]
    public string[] sentences;
}
