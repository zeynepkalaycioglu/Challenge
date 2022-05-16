using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SingleCoin : ObjectMoving
{
    void Start()
    {
        isVerticalMovement = true;
        if(isVerticalMovement)
            StartCoroutine((VerticalMovementAndRotate()));   
    }

    private IEnumerator VerticalMovementAndRotate()
    { 
        yield return new WaitForSeconds(verticalMovementDelay);
        transform.DOKill();
        transform.DOMoveY(transform.position.y + verticalMoveAmount, verticalMoveSpeed).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);

        transform.DORotate(new Vector3(0f,-180f,0f),rotateSpeed,RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
}
