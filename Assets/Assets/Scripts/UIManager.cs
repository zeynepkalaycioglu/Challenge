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
    
    public int currentScore = 0;
    public Text scoreText;
    
    
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
        GameManager.Instance.score = PlayerPrefs.GetInt("score", currentScore);
        scoreText.text = currentScore.ToString();
    }
    
    public void EndGame()
    {
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
