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

    public void LoadDisplaySettings (){
       SceneManager.LoadScene("Settings Display");
   }

   public void LoadAudioSettings (){
       SceneManager.LoadScene("Settings Audio");
   }

   public void LoadControlsSettings (){
        SceneManager.LoadScene("Settings Controls");
    }

   public void ExitGame (){
       Application.Quit();
       Debug.Log("Quit the game");
   }

   public void BackToMenu (){
       SceneManager.LoadScene("Menu");
   }

}
