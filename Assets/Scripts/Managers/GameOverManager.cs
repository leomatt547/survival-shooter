using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static TimeZen;

public class GameOverManager : MonoBehaviour
{
    public static int enemyDeath;
    public Text warningText;
    public Text gameOverText;
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public GameObject restartButton;
    public GameObject menuButton;
    public TimeboardManager timeboardManager;
    public TimeManager timeManager;
    public ScoreManager scoreManager;
    public ScoreboardManager scoreboardManager;
    public bool sudah_add_time;
    public bool sudah_add_score;

    // public WaveManager waveManager;

    Animator anim;
    float timer;

    void Start()
    {
        sudah_add_time = false;
        sudah_add_score = false;
        restartButton.SetActive(false);
        menuButton.SetActive(false);
        enemyDeath = 0;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            // Zen Mode
            if (timeboardManager != null)
            {
                string name = PlayerPrefs.GetString("user_name");
                gameOverText.text = "Game Over, " + name + "!";
                anim.SetTrigger("GameOver");

                timer += Time.deltaTime;
                if (timer > 1.5f)
                {
                    if (!sudah_add_time)
                    {
                        TimeZen hasil = new TimeZen(name, timeManager.GetTime());
                        timeboardManager.AddTime(hasil);
                        sudah_add_time = true;
                    }
                    timer = 0f;
                    restartButton.SetActive(true);
                    menuButton.SetActive(true);
                }
            }
            else
            {
                // Wave Mode
                string name = PlayerPrefs.GetString("user_name");
                gameOverText.text = "Game Over, " + name + "!";
                anim.SetTrigger("GameOver");
                timer += Time.deltaTime;
                if (timer > 1.5f)
                {
                    if (!sudah_add_score)
                    {
                        Score hasil = new Score(name, scoreManager.GetScore(), WaveManager.nWave);
                        scoreboardManager.AddScore(hasil);
                        sudah_add_score = true;
                    }
                    timer = 0f;
                    restartButton.SetActive(true);
                    menuButton.SetActive(true);
                }
            }


        }
    }

    public void ShowWarning(float enemyDistance)
    {
        if (playerHealth.currentHealth > 0)
        {
            warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
            anim.SetTrigger("Warning");

        }
    }
}