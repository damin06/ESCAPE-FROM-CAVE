using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text BestScoreTxt;
    private int bestScore;
    public Text currentScoreTxt;
    private int currentScore; 
      public void SetScore(int value)
    {
        currentScore=value;
        currentScoreTxt.text = "SCORE " + currentScore;
        PlayerPrefs.SetInt("Score", currentScore);
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            BestScoreTxt.text = "BEST SCORE " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }
    public int GetScore()
    {
        return currentScore;
    }
       void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        BestScoreTxt.text = "BEST SCORE " + bestScore;
    }
}
