using UnityEngine;
using UnityEngine.UI;
using System;

public class WaveManager : MonoBehaviour
{
    public static int nWave;
    Text waveText;

    // at start
    void Awake ()
    {
        waveText = GetComponent<Text>();
        nWave = 1;
    }

    // per frame
    void Update ()
    {
        string boss = "";
        if (nWave % 3 == 0) {
            boss = " (BOSS)";
        }
        waveText.text = "Wave: " + nWave;
    }
}
