using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUi : MonoBehaviour
{
    public RowUiZen rowUi;
    public TimeboardManager timeManager;

    // Start is called before the first frame update
    void Start()
    {        
        // timeManager.AddTime(new Time("eran2", 77));

        var times = timeManager.GetHighTimes().ToArray();
        for(int i=0; i < times.Length; i++){
            var row = Instantiate(rowUi, transform).GetComponent<RowUiZen>();
            row.rank.text = (i+1).ToString();
            row.name.text = times[i].name;
            row.time.text = this.printTime(times[i].time);
        }
    }

    string printTime(float secs){
        TimeSpan timeSpan = TimeSpan.FromSeconds(secs);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }

}
