using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    [Header("Put name of the next Scene here")]
    public string levelName;

    void OnTriggerEnter(Collider other)
    {
            SceneManager.LoadScene(levelName);
    }
}
