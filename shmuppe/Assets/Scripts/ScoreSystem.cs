﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score = 0;

    public int Score
    {
        get { return score; }
        set { score = score + value; }
    }

    public void Reset()
    {
        score = 0;
    }

}
