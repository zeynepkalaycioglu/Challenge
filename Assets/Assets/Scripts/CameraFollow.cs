using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    public GameObject target;
    public Vector3 distance;


    void LateUpdate()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Move)
        {
          this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime);
        }
    }

}
