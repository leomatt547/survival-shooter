using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalMenu : MonoBehaviour
{
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
