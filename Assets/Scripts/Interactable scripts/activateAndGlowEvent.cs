using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class activateAndGlowEvent : MusicInteractable
{
    //for spawning the glow object
    public GameObject glowObject;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        //Deactivate the "musicObjectCode", so it can be activated later, once the player plays the right note first.
        if (GetComponent<musicObjectCode>())
            GetComponent<musicObjectCode>().enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (bardSong.Substring(bardSong.Length - solutionLength) == triggerSolution &&
           distanceToPlayerXZ <= activationRangeWidth && //Checking width
           Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight && //Checking height
           canActivate == true)
        {
            startGlow();
        }
    }

    //This one is activated via Sequence Puzzle
    public void activate()
    {
        startGlow();
    }

    void startGlow()
    {
        if (GetComponent<musicObjectCode>()) //Just checking if this script excists, then activates it.
        {
            Debug.Log("GLOW!");
            Instantiate(glowObject, transform.position, transform.rotation);
            GetComponent<musicObjectCode>().enabled = true;
            canActivate = false;
        }
        else
        {
            Debug.Log("GLOW!");
            Instantiate(glowObject, transform.position, transform.rotation);
            canActivate = false;
        }
    }
}
