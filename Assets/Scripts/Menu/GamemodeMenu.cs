using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemodeMenu : MonoBehaviour
{
    public void ZenMode()
    {
        SceneManager.LoadScene("MapMenuZen");
    }

    public void WaveMode()
    {
        SceneManager.LoadScene("MapMenuWave");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
