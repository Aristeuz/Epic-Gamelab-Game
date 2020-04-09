using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escMenu : MonoBehaviour
{
    public GameObject escapeMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeMenu.gameObject.SetActive(!escapeMenu.gameObject.activeSelf);
        }
    }
}
