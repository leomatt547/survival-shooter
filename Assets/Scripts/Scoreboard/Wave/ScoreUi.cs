using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    public RowUi rowUi;
    public ScoreboardManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        // scoreManager.AddScore(new Score("eran2", 77));

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.wave.text = scores[i].wave.ToString();
            row.score.text = scores[i].score.ToString();
        }
    }

}
