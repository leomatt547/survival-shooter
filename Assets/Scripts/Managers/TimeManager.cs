using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour
{
    public static float time;
    public PlayerHealth playerHealth;
    Text text;
    private bool sudah;
    private int upgradeDelay;


    void Awake()
    {
        sudah = false;
        text = GetComponent<Text>();
        time = 0;
        upgradeDelay = 30;
    }


    void Update()
    {
        if (playerHealth.currentHealth > 0f)
        {
            time += Time.deltaTime;
            if (Math.Floor(time % upgradeDelay) == 0f && !sudah && time > 1)
            {
                sudah = true;
                UpgradeWeapon.GameIsPaused = true;

            }
            if (time % upgradeDelay > 1f && sudah)
            {
                sudah = false;
            }
        }
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string timeLeft = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        text.text = "Time: " + timeLeft;
    }

    public float GetTime()
    {
        return time;
    }
}
