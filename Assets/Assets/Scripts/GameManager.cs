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
    

    public void StartGame()
    {
        uiManager.StartGame();
        playerManager.playerState = PlayerManager.PlayerState.Move;
        //SoundManager.Instance.PlayBgMusic(SoundManager.BgMusicTypes.MainBgMusic);
    }
    
    public void FailedGame()
    {
       uiManager.FailedGame();
       playerManager.playerState = PlayerManager.PlayerState.Stop;
    }
    public void EndGame()
    {
        //SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Congratz);
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
}
