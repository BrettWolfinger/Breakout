using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI text;
    int score = 0;
    public static Action<int> NewHighScore = delegate { };
    HighScoreManager highScoreManager;

    void Awake()
    {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Score: " + score.ToString();
    }

    void OnEnable()
    {
        BrickBehaviour.BrickWasDestroyed += UpdateScore;
    }

    void OnDisable()
    {
        BrickBehaviour.BrickWasDestroyed -= UpdateScore;
    }

    void UpdateScore(int value)
    {
        score += value;
        text.text = "Score: " + score.ToString();
        if(score > highScoreManager.GetHighScore())
        {
            NewHighScore.Invoke(score);
        }
    }
}