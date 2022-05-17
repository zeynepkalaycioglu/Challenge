using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public void CoinCollected(GameObject coin)
    {

        coin.gameObject.SetActive(false);

    }
    
    public void ObstacleCrashed(GameObject obstacle)
    {

        obstacle.gameObject.SetActive(false);

    }
}
