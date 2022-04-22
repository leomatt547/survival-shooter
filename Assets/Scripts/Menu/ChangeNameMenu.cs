using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeNameMenu : MonoBehaviour
{
    public InputField obj_text;

    public void Awake(){
        obj_text.text = PlayerPrefs.GetString("user_name");
    }
    public void SaveName(){
        PlayerPrefs.SetString("user_name", obj_text.text);
        GoToSettingsMenu();
    }

    public void GoToSettingsMenu(){
        SceneManager.LoadScene("SettingsMenu");
    }
}
