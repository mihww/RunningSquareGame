using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Score : MonoBehaviour
{
    public static int scoreValue;
    private static int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private string highScoreFilePath;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreValue = 0;
        highScoreFilePath = Path.Combine(Application.persistentDataPath, "highscore.txt");

        LoadHighScore();

        highScoreText.text = "High Score: " + highScore;
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue;

        if (scoreValue > highScore)
        {
            highScore = scoreValue;
            SaveHighScore();
            
        }
    }

    void SaveHighScore()
    {
        File.WriteAllText(highScoreFilePath, highScore.ToString());
    }

    void LoadHighScore()
    {
        if (File.Exists(highScoreFilePath))
        {
            string highScoreString = File.ReadAllText(highScoreFilePath);
            if (int.TryParse(highScoreString, out int loadedHighScore))
            {
                highScore = loadedHighScore;
            }
        }
    }
}