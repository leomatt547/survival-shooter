using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardMenu : MonoBehaviour
{
    public void GotoWaveScoreboard(){
        SceneManager.LoadScene("WaveScoreboard");
    }

    public void GotoZenScoreboard(){
        SceneManager.LoadScene("ZenScoreboard");
    }

    public void GoToSettingsMenu(){
        SceneManager.LoadScene("SettingsMenu");
    }
}
