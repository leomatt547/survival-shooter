using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TimeData
{
    public List<TimeZen> times;
   
    public TimeData(){
        times = new List<TimeZen>();
    }
}
