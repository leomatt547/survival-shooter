using UnityEngine;
using UnityEngine.UI;
using System;

public class NameManager : MonoBehaviour
{
    Text text;

    void Awake ()
    {
        text = GetComponent<Text>();
        text.text = "Player: " + PlayerPrefs.GetString("user_name");
    }


    void Update ()
    {
       //
    }
}
