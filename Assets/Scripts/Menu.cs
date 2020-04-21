using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   //currently both resume and new game, will go to the demo scene, as there is no save game option yet
    public void StartGame (){
        SceneManager.LoadScene("Demo Scene");
    }

    public void LoadSettings (){
        SceneManager.LoadScene("Settings");
    }

   public void ExitGame (){
       Application.Quit();
       Debug.Log("Quit the game");
   }

   public void BackToMenu (){
       SceneManager.LoadScene("Menu");
   }


}
