using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text text;
    private int score = 0;

    public int PlayerScore
    {
        get { return score; }
    }
    
    public void AddScore(int points)
    {
        if (!GameManager.isOver)
        {
            score += points;
            text.text = "SCORE: " + score;
        }
    }
}
