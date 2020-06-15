using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform Player;
    public Transform teleportLocation;
    [HideInInspector]
    public Component clickToMove;

    private void Start()
    {
        clickToMove = Player.GetComponent<ClickToMove>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.position = teleportLocation.position;
            clickToMove.GetComponent<ClickToMove>().enabled = false;
        }
    }
}
