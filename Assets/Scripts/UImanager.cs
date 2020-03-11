using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This script interacts with the UI buttons, and lets you press buttons like 1,2,3 to activate with them.
public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Button[] actionButtons;

    private KeyCode action1, action2, action3, action4;
    public GameObject primeMusic;

    void Start()
    {
        primeMusic = GameObject.Find("Player/PlayerCollider");
        //Debug.Log (primeMusic.name);
        //Keybinds
        action1 = KeyCode.Alpha1;
        action2 = KeyCode.Alpha2;
        action3 = KeyCode.Alpha3;
        action4 = KeyCode.Alpha4;
    }

    // Update is called once per frame
    void Update()
    {
        //Clicking on the buttons with the mouse doesn't play sounds for some reason.
        if (Input.GetKeyDown(action1))
        {
            ActionButtonOnClick(0);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("a");
        }
        if (Input.GetKeyDown(action2))
        {
            ActionButtonOnClick(1);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("b");
        }
        if (Input.GetKeyDown(action3))
        {
            ActionButtonOnClick(2);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("c");
        }
        if (Input.GetKeyDown(action4))
        {
            ActionButtonOnClick(3);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("d");
        }
    }

    //Makes the button when pressed(1,2,3) do the same action when clicked on.
    private void ActionButtonOnClick(int buttonIndex)
    {
        actionButtons[buttonIndex].onClick.Invoke();
    }
}
