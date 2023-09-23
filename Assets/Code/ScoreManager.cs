using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    public Action<int> OnHighScoreChanged;
    
    public int Score { get; private set; }
    public int HighScore { get;  private set; }

    private void Awake()
    {
        Instance = this;
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        InvokeRepeating(nameof(SecondUpdate), 1, 1);
    }
    
    public void AddScore(int score)
    {
        Score += score;
        Debug.Log("High score is: " + HighScore);
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            OnHighScoreChanged?.Invoke(HighScore);
            Debug.Log("Updating high score, it is: " + HighScore);
        }
        OnScoreChanged();
    }
    private void SecondUpdate()
    {
        AddScore(1);
    }

    private void OnScoreChanged()
    {
        if (scoreText != null)
        {
            scoreText.text = Score.ToString();
        }
    }
}
