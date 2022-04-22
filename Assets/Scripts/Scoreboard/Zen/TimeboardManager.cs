using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeboardManager : MonoBehaviour
{
    private TimeData sd;
    void Awake(){
        var json = PlayerPrefs.GetString("times", "{}");
        sd = JsonUtility.FromJson<TimeData>(json);
    }

    public IEnumerable<TimeZen> GetHighTimes(){
        return sd.times.OrderByDescending(x=>x.time);
    }

    public void AddTime(TimeZen time){
        sd.times.Add(time);
    }

    private void OnDestroy(){
        SaveTime();
    }

    public void SaveTime(){
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("times", json);
    }
}
