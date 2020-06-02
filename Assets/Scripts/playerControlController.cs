using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlController : MonoBehaviour
{
    private Component clickToMoveScript;
    private Component playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        clickToMoveScript = GetComponent<ClickToMove>();
        playerControllerScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            playerControllerScript.GetComponent<PlayerController>().enabled = false;
            clickToMoveScript.GetComponent<ClickToMove>().enabled = true;
        }

        //controller input
        if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Vertical") > 0.1)
        {
            playerControllerScript.GetComponent<PlayerController>().enabled = true;
            clickToMoveScript.GetComponent<ClickToMove>().enabled = false;
        }
    }
}
