using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
   public Animator characterAnimator;

   private void Start()
   {
      characterAnimator.SetBool("isLevelCompleted", false);
   }

   public void LevelWin()
   {
      characterAnimator.SetBool("isLevelCompleted", true);
   }
}
