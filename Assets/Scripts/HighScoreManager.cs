using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    TextMeshProUGUI text;
    HighScore highScore;

    void Awake()
    {
        highScore = new HighScore();
        Load();
        text = GetComponent<TextMeshProUGUI>();
        text.text = "High Score: " + highScore.score.ToString();
    }

    void OnEnable()
    {
        ScoreManager.NewHighScore += UpdateHighScore;
    }

    void OnDisable()
    {
        ScoreManager.NewHighScore -= UpdateHighScore;
    }

    void UpdateHighScore(int newHighScore)
    {
        highScore.score = newHighScore;
        text.text = "High Score: " + highScore.score.ToString();
        Save();
    }

    void Load()
    {
        string json = System.IO.File.ReadAllText("C:/Users/bdwol/Documents/Unity_Projects/Breakout/HighScore.json");
        JsonUtility.FromJsonOverwrite(json, highScore);
    }

    void Save()
    {
        string json = JsonUtility.ToJson(highScore);
        print(json);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/HighScore.json", json);
        System.IO.File.WriteAllText("C:/Users/bdwol/Documents/Unity_Projects/Breakout/HighScore.json", json);
    }

    public int GetHighScore()
    {
        return highScore.score;
    }
}

[System.Serializable]
public class HighScore
{
    public int score;
}

