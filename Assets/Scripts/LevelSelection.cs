using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

   private void Start() {
      Time.timeScale = 1;
   }

   public void Lvl1 (){
    SceneManager.LoadScene("Level 1");
   }

   public void Lvl2 (){
    SceneManager.LoadScene("Level 2");
   }

   public void Lvl3 (){
    SceneManager.LoadScene("Level 3");
   }

   public void Lvl4 (){
    SceneManager.LoadScene("Level 4");
   }

   public void Lvl5 (){
    SceneManager.LoadScene("Level 5");
   }

   public void Lvl7 (){
    SceneManager.LoadScene("Level 7");
   }

   public void Lvl8 (){
    SceneManager.LoadScene("Level 8");
   }

   public void Lvl9 (){
    SceneManager.LoadScene("Level 9");
   }
}
