using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject splashScreen;
    public GameObject gameScreen;
    public GameObject gameEndScreen;
    public GameObject failScreen;
    public GameObject levelMapScreen;
    
    public int currentScore;
    public Text scoreText;
    public Text gainedScoreText;

    public int endScore;
    
    
    private void Start()
    {
        currentScore = GameManager.Instance.score;
    }
    
    public void PlayButtonPressed()
    {
        GameManager.Instance.StartGame();
    }

    public void LevelMapButtonPressed()
    {
        splashScreen.SetActive(false);
        levelMapScreen.SetActive(true);
    }
    public void CloseLevelMap()
    {
        splashScreen.SetActive(true);
        levelMapScreen.SetActive(false);
    }

    public void StartGame()
    {
        splashScreen.SetActive(false);
        gameScreen.SetActive(true);
        GameManager.Instance.score = PlayerPrefs.GetInt("score", GameManager.Instance.score);
        scoreText.text = GameManager.Instance.score.ToString();
    }
    
    public void EndGame()
    {
        ScoreCalculationEnd(GameManager.Instance.playerCollectible.calculatedScore);
        gameScreen.SetActive(false);
        gameEndScreen.SetActive(true);
    }
    
    public void FailedGame()
    {
        gameScreen.SetActive(false);
        failScreen.SetActive(true);
    }
    
    public void CoinCollected(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }

    public void ScoreCalculationEnd(float gainedScore)
    {
        gainedScoreText.text = gainedScore.ToString();
    }

    public void PrefSaving()
    {
        SaveScore();
        PlayerPrefs.Save();
    }
    public void SaveScore()
    {   
        PlayerPrefs.SetInt("score", GameManager.Instance.score);     
    }


}
