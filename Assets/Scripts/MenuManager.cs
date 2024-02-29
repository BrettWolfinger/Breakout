using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MenuManager : MonoBehaviour
{
    GameObject restartMenu;
    TextMeshProUGUI playAgainText;

    void Awake()
    {
        restartMenu = GameObject.Find("RestartMenu");
        playAgainText = GameObject.Find("PlayAgain").GetComponent<TextMeshProUGUI>();
        restartMenu.SetActive(false);
    }

    void OnEnable()
    {
        LivesManager.GameOver += OpenMenu;
        BrickManager.AllBricksDestroyed += BricksDestroyedEnding;
        ScoreManager.NewHighScore += ShowHighScore;
    }

    void OnDisable()
    {
        LivesManager.GameOver -= OpenMenu;
        BrickManager.AllBricksDestroyed -= BricksDestroyedEnding;
        ScoreManager.NewHighScore -= ShowHighScore;
    }

    void OpenMenu()
    {
        Time.timeScale = 0;
        //playAgainText.text = "Found ya";
        restartMenu.SetActive(true);
    }

    private void BricksDestroyedEnding()
    {
        playAgainText.text = "Wow! All Bricks Destroyed!\nPlay again?";
        OpenMenu();
    }

    void ShowHighScore(int newHighScore)
    {
        playAgainText.text = "New High Score!\n" + newHighScore.ToString() + "\nPlay again?";
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}
