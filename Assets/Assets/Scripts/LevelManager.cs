using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public string nextLevel;
 
    
   public void LevelCompletedButton()
   {
      if (nextLevel != null)
      {
         SceneManager.LoadScene(nextLevel);
      }
   }

 
   
   public void ReplayScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }


   public void OpenLevel1Scene()
   {
      SceneManager.LoadScene("Level1");
   }
   
   public void OpenLevel2Scene()
   {
      SceneManager.LoadScene("Level2");
   }
}
