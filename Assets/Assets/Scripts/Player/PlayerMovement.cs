using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardMoveSpeed;
    [SerializeField] private float leftRightMoveSpeed;

    public PlayerManager playerManager;
    public PlayerAnimations playerAnimations;
    public Button powerUpButton;

    void Update()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Move)
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * leftRightMoveSpeed * Time.deltaTime;
            this.transform. Translate(-forwardMoveSpeed * Time.deltaTime, 0, horizontalMovement);
        }
        else
        {
            
        }
        if (playerManager.playerState == PlayerManager.PlayerState.Win)
        {
            playerAnimations.LevelWin();
        }
    }

    public void PlayerPressedPowerUpButton()
    {
        Debug.Log(forwardMoveSpeed);
        forwardMoveSpeed = forwardMoveSpeed * 2.5f;
        StartCoroutine(UsingPowerUp());
    }
    
    IEnumerator UsingPowerUp()
    {
        powerUpButton.interactable = false;
        yield return new WaitForSeconds(5.0f);
        forwardMoveSpeed = forwardMoveSpeed / 2.5f;
    }
}
