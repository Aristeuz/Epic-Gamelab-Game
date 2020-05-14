using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code is used for the puzzles like "doors with light", not the "pillar puzzle" 

public class PuzzleFeedbackController : MusicInteractable
{
    [HideInInspector]
    public int order = 0;
    private Transform firstChild;
    private bool correctNote = false;
    //private bool canActivate = true; 

    public DestroyEvent _destroyEvent;
    public activateAndGlowEvent _activateAndGlowEvent;
    public moveEvent _moveEvent;

    public List<PuzzleFeedbackLight> tag_targets = new List<PuzzleFeedbackLight>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        firstChild = this.gameObject.transform.GetChild(0);

        foreach (Transform child in transform)
        {
            tag_targets.Add(child.GetComponent<PuzzleFeedbackLight>());
        }
        //Debug.Log(tag_targets.Count);

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        int listLengthMinusOne = tag_targets.Count - 1 - order; //Takes the length of the list (children) -1 because it counts itself aswell otherwise, - order so it knows at what number they are. 

        //If any of the keys are pressed.
        if (Input.GetKeyDown(KeyCode.Alpha1) ||
           Input.GetKeyDown(KeyCode.Alpha2) ||
           Input.GetKeyDown(KeyCode.Alpha3) ||
           Input.GetKeyDown(KeyCode.Alpha4))
        {
            notePlayed = true;
        }
        if (PrimeMusicManager.instance.missed == true)
        {
            if (canActivate == true)
            restart();
        }

        if (PrimeMusicManager.instance.beat == true)
        {
            //Debug.Log(triggerSolution.Substring(0, triggerSolution.Length - listLengthMinusOne) + " Selution");
            if (notePlayed == true)
            {
                if (canActivate == true)
                {
                    //Calcualtes and find out if what you just played is the same as the Trigger selution based on the order. 
                    //e.g. Trigger selution = abcb. if the order is 3. you only have to play abc in order to up the order.

                    if (bardSong.Substring(bardSong.Length - solutionLength + listLengthMinusOne) == triggerSolution.Substring(0, triggerSolution.Length - listLengthMinusOne) &&
                    distanceToPlayerXZ <= activationRangeWidth && //Checking width
                    Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight) //Checking height)
                    {
                        tag_targets[order].gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(0f, 0f, 1f, 1f)); // blue
                        order += 1;

                        //if everything is correct
                        if (order == tag_targets.Count)
                        {
                            Debug.Log("Complete");
                            complete();
                        }
                    }
                    else if (bardSong.Substring(bardSong.Length - solutionLength + listLengthMinusOne) != triggerSolution.Substring(0, triggerSolution.Length - listLengthMinusOne) &&
                    distanceToPlayerXZ <= activationRangeWidth && //Checking width
                    Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight) //Checking height
                    {
                        Debug.Log(canActivate);
                        restart();
                    }
                }
            }
            //musicTimer = 0f;
            notePlayed = false;            
        }
    }

    void restart()
    {
        foreach (Transform child in transform)
        {
            child.transform.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(1f, 0f, 0f, 1f)); // red
        }      
        canActivate = true;
        order = 0;
        PrimeMusicManager.instance.missed = false;
    }

    void complete()
    {
        foreach (Transform child in transform)
        {
            child.transform.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(0f, 1f, 0f, 1f)); // Green
        }

        canActivate = false;

        //Activate event script if it has one of them.
        if (_destroyEvent != null)
            _destroyEvent.activate();
        if (_activateAndGlowEvent != null)
            _activateAndGlowEvent.activate();
        if (_moveEvent != null)
            _moveEvent.activate();
    }
}
