using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillManager : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Kills: " + GameOverManager.enemyDeath;
    }
}
