using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMenu : MonoBehaviour
{

    [Header("Put name of the next Scene here")]
    public string levelName;

    public float time;
    public float TimeLimit = 10;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= TimeLimit)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
