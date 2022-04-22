using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TimeZen
{
    public string name;
    public float time;
   
    public TimeZen(string name, float time){
        this.name = name;
        this.time = time;
    }
}
