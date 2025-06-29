using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text =  "You Scored:\n" + scoreKeeper.GetScore();
        highScoreText.text = "High Score:\n" + scoreKeeper.GetHighScore();
    }

  
   
}
