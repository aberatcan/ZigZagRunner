using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIElementsController : MonoBehaviour
{
    public static UIElementsController instance;

    [SerializeField]
    TMP_Text ScoreText;

    [SerializeField]
    TMP_Text HighScoreText;

    [SerializeField]
    GameObject LevelResultPanel;

    [HideInInspector]
    int currentScore = 0;

    [HideInInspector]
    int highScore;

    public bool isGameFinished;

    private void Awake()
    {
        instance = this;   
    }

    private void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsGameFinished();

        // Check if the current score is higher than the high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
            HighScoreText.text = "High Score: " + highScore.ToString();

            // Save the new high score
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public IEnumerator UpdateScoreRoutine(float ballSpeed)
    {
        while(!isGameFinished)
        {
            currentScore++;
            ScoreText.text = currentScore.ToString();
            yield return new WaitForSeconds(ballSpeed/3);
        }
    }

    public void UpdateScore(int incomingScore)
    {
        currentScore = incomingScore;
        ScoreText.text = currentScore.ToString();
    }

    void CheckIsGameFinished()
    {
        if(isGameFinished)
        {
            LevelResultPanel.SetActive(true);
            
        }
    }

    public void RestartGame()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }

    private void OnDestroy()
    {
        // Save the high score when the game ends or the object is destroyed
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}
