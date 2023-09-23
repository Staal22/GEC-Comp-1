using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        ScoreManager.Instance.OnHighScoreChanged += UpdateHighScoreText;
        UpdateHighScoreText(ScoreManager.Instance.HighScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    private void UpdateHighScoreText(int highScore)
    {
        highScoreText.text = highScore.ToString();
    }
}
