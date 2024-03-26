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

    //After game ends stop gameplay and open restart menu 
    void OpenMenu()
    {
        Time.timeScale = 0;
        restartMenu.SetActive(true);
    }

    //Change text on restart screen if all bricks destroyed
    private void BricksDestroyedEnding()
    {
        playAgainText.text = "Wow! All Bricks Destroyed!\nPlay again?";
        OpenMenu();
    }

    //Change text on restart screen if new high score achieved
    void ShowHighScore(int newHighScore)
    {
        playAgainText.text = "New High Score!\n" + newHighScore.ToString() + "\nPlay again?";
    }

    //Start gameplay over
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}
