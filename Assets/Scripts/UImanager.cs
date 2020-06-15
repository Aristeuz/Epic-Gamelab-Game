using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This script interacts with the UI buttons, and lets you press buttons like 1,2,3 to activate with them.
public class UImanager : MonoBehaviour
{
    public GameObject menu;
    bool menuActive = false;

    [SerializeField]
    private Button[] actionButtons;

    private KeyCode action1, action2, action3, action4;
    public GameObject primeMusic;

    //[HideInInspector]
    public bool unlockOne = false;
    //[HideInInspector]
    public bool unlockTwo = false;

    public Image buttonImage1;
    public Image buttonImage2;
    public Image buttonImage3;
    public Image buttonImage4;

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
            buttonImage1.color = new Color(1, 0, 0);
        }
        else
        {
            buttonImage1.color = new Color(1, 1, 1);
        }
        if(Input.GetKeyDown(action2) && unlockOne == true || bButton && unlockOne == true)
        {
            ActionButtonOnClick(1);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("b");
            buttonImage2.color = new Color(1, 0, 0);
        }
        else
        {
            buttonImage2.color = new Color(1, 1, 1);
        }
        if (Input.GetKeyDown(action3) && unlockTwo == true || xButton && unlockTwo == true)
        {
            ActionButtonOnClick(2);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("c");
            buttonImage3.color = new Color(1, 0, 0);
        }
        else
        {
            buttonImage3.color = new Color(1, 1, 1);
        }
        if (Input.GetKeyDown(action4) && unlockTwo == true || yButton && unlockTwo == true)
        {
            ActionButtonOnClick(3);
            primeMusic.GetComponent<PrimeMusicManager>().currentNote = ("d");
            buttonImage4.color = new Color(1, 0, 0);
        }
        else
        {
            buttonImage4.color = new Color(1, 1, 1);
        }


        if (Input.GetKeyDown(KeyCode.Escape) && menu)
        {
            Debug.Log("Escape key was pressed");
            if (menuActive == true)
                menu.SetActive(false);

            if (menuActive == false)
                menu.SetActive(true);

            menuActive = !menuActive;
        }
    }

    //Makes the button when pressed(1,2,3) do the same action when clicked on.
    private void ActionButtonOnClick(int buttonIndex)
    {
        actionButtons[buttonIndex].onClick.Invoke();
    }
}
