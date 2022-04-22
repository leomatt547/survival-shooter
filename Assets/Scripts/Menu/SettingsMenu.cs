using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void ChangeName(){
        SceneManager.LoadScene("ChangeNameMenu");
    }

    public void GotoScoreboard(){
        SceneManager.LoadScene("ZenScoreboard");
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
