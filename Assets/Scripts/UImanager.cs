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

    //[HideInInspector]
    public bool unlockOne = false;
    //[HideInInspector]
    public bool unlockTwo = false;

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
        bool aButton = Input.GetButtonDown("A Button");
        bool bButton = Input.GetButtonDown("B Button");
        bool xButton = Input.GetButtonDown("X Button");
        bool yButton = Input.GetButtonDown("Y Button");
        //Clicking on the buttons with the mouse doesn't play sounds for some reason.
        if (Input.GetKeyDown(action1) || aButton)
        {
            ActionButtonOnClick(0);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("a");
        }
        if(Input.GetKeyDown(action2) && unlockOne == true || bButton && unlockOne == true)
        {
            ActionButtonOnClick(1);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("b");
        }
        if (Input.GetKeyDown(action3) && unlockTwo == true || xButton && unlockTwo == true)
        {
            ActionButtonOnClick(2);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("c");
        }
        if (Input.GetKeyDown(action4) && unlockTwo == true || yButton && unlockTwo == true)
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
