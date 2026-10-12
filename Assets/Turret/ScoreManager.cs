using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    TMP_Text scoreCounter;

    private void Start()
    {
        scoreCounter = GetComponent<TMP_Text>();
        scoreCounter.text = score.ToString();
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreCounter.text = score.ToString();
    }

}
