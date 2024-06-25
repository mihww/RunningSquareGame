using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    private static int highScore { get; set; } = -1;
    public TextMeshProUGUI scoreText;
   

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>(); 
    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreValue;

        if(scoreValue > highScore)
        {
            highScore = scoreValue;

            File.AppendAllLines("highscore.txt", new string[] { highScore.ToString() });
        }
    }
    
}
