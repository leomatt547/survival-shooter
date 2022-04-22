using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public string name;
    public float score;

    public int wave;

    public Score(string name, float score, int wave)
    {
        this.name = name;
        this.score = score;
        this.wave = wave;
    }
}
