using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LivesManager : MonoBehaviour
{
    TextMeshProUGUI text;
    int lives = 3;
    public static Action GameOver = delegate { };

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Lives: " + lives.ToString();
    }

    void OnEnable()
    {
        BallMovement.MissedBall += LostLife;
    }

    void OnDisable()
    {
        BallMovement.MissedBall -= LostLife;
    }

    void LostLife()
    {
        lives -= 1;
        text.text = "Lives: " + lives.ToString();
        if(lives == 0)
        {
            GameOver.Invoke();
        }
    }
}
