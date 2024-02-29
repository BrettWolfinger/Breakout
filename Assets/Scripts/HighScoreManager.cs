using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    TextMeshProUGUI text;
    HighScore highScore;
    string path;
    void Awake()
    {
        highScore = new HighScore();
        path = Application.persistentDataPath + "/HighScore.json";
        print(path);
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
        //If there is no save file that exists, create one
        if (!File.Exists(path))
        {
            highScore.score = 0;
            Save();
        }
        string json = System.IO.File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, highScore);
    }

    void Save()
    {
        string json = JsonUtility.ToJson(highScore);
        System.IO.File.WriteAllText(path, json);
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

