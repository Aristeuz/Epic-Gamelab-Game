using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit(); // only works on build
    }
}
