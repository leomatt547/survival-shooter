using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuWave : MonoBehaviour
{
    public void WaveDollhouse()
    {
        SceneManager.LoadScene("Wave_Mode");
    }

    public void WaveConstruction()
    {
        SceneManager.LoadScene("Wave_Mode_Construction");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("GamemodeMenu");
    }
}
