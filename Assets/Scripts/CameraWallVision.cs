using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWallVision : MonoBehaviour
{
    private GameObject Obstruction;
    public Transform player;

    [Range(0, 1)]
    public float wallTransparency = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Obstruction = player.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Debug.DrawRay(transform.position, playerPos - transform.position, Color.green);
    }

    private void LateUpdate()
    {
        ViewObstructed();
    }

    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, 20f))
        {
            if (hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "Ground")
            {

                if (Obstruction == null)
                {
                    Obstruction = hit.collider.gameObject;
                }
                else if (hit.collider.gameObject != Obstruction)
                {
                    Obstruction.gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(1f, 1f, 1f, 1f));
                    Obstruction = hit.collider.gameObject;
                    //iTween.FadeTo(Obstruction, 0, 1); //Doesn't seem to work becasue we are using a different shader. I tween works with the Unity renderer to fade things.
                    Obstruction.gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(wallTransparency, wallTransparency, wallTransparency, wallTransparency));
                }
            }
            else
            {
                if (Obstruction != null)
                {
                    Obstruction.gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(1f, 1f, 1f, 1f));
                    //iTween.FadeTo(Obstruction, 1, 1);
                }
                Obstruction = null;
            }
        }
    }
}
