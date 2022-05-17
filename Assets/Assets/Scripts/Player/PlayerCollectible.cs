using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectible : MonoBehaviour
{
    public GameObject cube;
    public Vector3 sizeChange;
    public Vector3 endScale;
    public float calculatedScore;
    public float scaleAmount;
    public float endMultiplyAmount = 10f;

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
            collision.GetComponent<SphereCollider>().enabled = false;
            cube.transform.localScale += sizeChange;
            GameManager.Instance.CoinCollected(collision.gameObject);
            //SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Collect);
        }

        if (collision.transform.CompareTag("Obstacle025x"))
        {
            collision.GetComponent<SphereCollider>().enabled = false;
            cube.transform.localScale -= sizeChange;
            GameManager.Instance.ObstacleCrashed(collision.gameObject);
            //SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Crash);
        }
        
        if (collision.transform.CompareTag("Obstacle05x"))
        {
            collision.GetComponent<SphereCollider>().enabled = false;
            cube.transform.localScale -= sizeChange * 2;
            GameManager.Instance.ObstacleCrashed(collision.gameObject);
            //SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Crash);

        }
        
        if (collision.transform.CompareTag("WinDetector"))
        {
            WinScoreCalculation();
            GameManager.Instance.EndGame();
        }

    }

    public void WinScoreCalculation()
    {
       endScale.y = cube.transform.localScale.y;
       scaleAmount = endScale.y;
       calculatedScore = scaleAmount * endMultiplyAmount;
       Debug.Log(endScale.y + " end scale value");
       Debug.Log(calculatedScore);
    }
}
