using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectible : MonoBehaviour
{
    public GameObject cube;
    public Vector3 sizeChange;


    private void Update()
    {
        if(cube.transform.localScale == new Vector3(1f, -0.5f, 1f) 
           || cube.transform.localScale == new Vector3(1f, -0.25f, 1f)
           || cube.transform.localScale == new Vector3(1f, 0f, 1f))
        {
            GameManager.Instance.FailedGame();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            Debug.Log("collided coin");
            collision.GetComponent<SphereCollider>().enabled = false;
            cube.transform.localScale += sizeChange;
            GameManager.Instance.CoinCollected(collision.gameObject);
            //SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Collect);
        }

        if (collision.transform.CompareTag("Obstacle025x"))
        {
            Debug.Log("collided 025");
            collision.GetComponent<SphereCollider>().enabled = false;
            cube.transform.localScale -= sizeChange;
            //GameManager.Instance.PlayerCrashedObstacle();
            //SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Crash);
        }
        
        if (collision.transform.CompareTag("Obstacle05x"))
        {
            Debug.Log("collided 05");
            collision.GetComponent<SphereCollider>().enabled = false;
            cube.transform.localScale -= sizeChange * 2;
                //GameManager.Instance.PlayerCrashedObstacle();
                //SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Crash);
         
            
           
            
        }
        
        if (collision.transform.CompareTag("WinDetector"))
        {
            Debug.Log("collided win detector");
            GameManager.Instance.EndGame();
        }

    }
}
