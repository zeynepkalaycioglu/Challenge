using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public UIManager uiManager;
    public PlayerManager playerManager;
    public PlayerCollectible playerCollectible;
    public CollectibleManager collectibleManager;
    
     
    public int score;
    public float winScoreBonus;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SoundManager.Instance.PlayBgMusic(SoundManager.BgMusicTypes.MainBgMusic);
    }

    public void StartGame()
    {
        uiManager.StartGame();
        playerManager.playerState = PlayerManager.PlayerState.Move;
    }
    
    public void FailedGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Lose);
        uiManager.FailedGame();
        playerManager.playerState = PlayerManager.PlayerState.Stop;
    }
    public void EndGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Congratz);
        CalculatingEndScore();
        CalculatingFinalScoreUI();
        uiManager.EndGame();
        uiManager.PrefSaving();
        playerManager.playerState = PlayerManager.PlayerState.Win;
    }
    
    public void CoinCollected(GameObject coin)
    {
        score++;
        uiManager.CoinCollected(score);   
        collectibleManager.CoinCollected(coin);
    }
    
    public void ObstacleCrashed(GameObject obstacle)
    { 
        collectibleManager.ObstacleCrashed(obstacle);
    }

    public void CalculatingEndScore()
    {
        winScoreBonus = score + playerCollectible.calculatedScore;
        uiManager.ScoreCalculationEnd(playerCollectible.calculatedScore);
        
        Debug.Log(winScoreBonus + " win score");
        score += (int)winScoreBonus;
    }

    public void CalculatingFinalScoreUI()
    {
        uiManager.ScoreCalculationEndForUI(playerCollectible.calculatedScore + score);
    }
}
