using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuZen : MonoBehaviour
{
    public void MapZenDollhouse()
    {
        SceneManager.LoadScene("Zen_Mode");
    }

    public void MapZenConstruction()
    {
        SceneManager.LoadScene("Zen_Mode_Construction");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("GamemodeMenu");
    }
}
