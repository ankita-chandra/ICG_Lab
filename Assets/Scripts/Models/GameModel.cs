using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel
{
    public int score;
    public int incrementValue;
}

public enum State
{
    GAME,
    REST,
    OVER
}