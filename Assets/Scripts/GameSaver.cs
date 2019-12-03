using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaver
{
    public static readonly string filename = "data.save";

    public int level { get; set; }
}
