using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparentScript : MonoBehaviour
{
    private GameObject player;
    public float fadeDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Debug.Log(this.gameObject.layer);
    }

    // Update is called once per frame
    void Update()
    {

        //Makes the platform transparent if the platform's .y is higher than the player + a little extra.
        if ((player.transform.position.y + fadeDistance) < transform.position.y)
        {
            GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(0.5f, 0.5f, 0.5f, 0.5f)); // Makes object transparent.
            gameObject.layer = 0;
        }
        else
        {
            GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(1, 1, 1, 1f));
            gameObject.layer = 8;
        }
    }
}

