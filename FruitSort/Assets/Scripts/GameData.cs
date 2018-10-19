using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public static GameData current;
    public static int points;

    public int Points { get { return points; } set { points = value; } }
}
