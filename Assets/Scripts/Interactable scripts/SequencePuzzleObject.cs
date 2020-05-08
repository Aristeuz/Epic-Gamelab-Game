using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePuzzleObject : MusicInteractable
{
    [HideInInspector]
    public SequencePuzzle sequencePuzzle;
    public int order = 0;
    private bool correctNote = false;
    int correctnumber;

    private bool activatedBool = false;

    private Transform firstChild;
    private Light myLight;
    Color color1 = Color.white;
    Color color2 = Color.red;
    Color color3 = Color.blue;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        firstChild = this.gameObject.transform.GetChild(0);
        myLight = firstChild.GetComponent<Light>();
    }

    // Update is called once per frame

     protected override void Update()
    {
        base.Update();

        //If any of the keys are pressed.
        if (Input.GetKeyDown(KeyCode.Alpha1) || 
           Input.GetKeyDown(KeyCode.Alpha2) ||
           Input.GetKeyDown(KeyCode.Alpha3) ||
           Input.GetKeyDown(KeyCode.Alpha4))
        {
            notePlayed = true;
        }

        float dist = Vector3.Distance(player.transform.position, transform.position);

        //Debug.Log(PrimeMusicManager.instance.beat);

        if (PrimeMusicManager.instance.beat == true)
        {
            //Debug.Log(this.gameObject.name + " notePlayed " + notePlayed );
            //Debug.Log(this.gameObject.name);
            //Debug.Log("Current list = " + bardSong);
            if (notePlayed == true)
            {
                if (bardSong.Substring(bardSong.Length - solutionLength) == triggerSolution && // if note is correct.
                distanceToPlayerXZ <= activationRangeWidth && //Checking width
                Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight && //Checking height
                canActivate == true)
                {
                    correctNote = true;
                    canActivate = false;
                    react();
                    interact();
                }
                else if (bardSong.Substring(bardSong.Length - solutionLength) != triggerSolution && // if note is incorrect.
                distanceToPlayerXZ <= activationRangeWidth && //Checking width
                Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight && //Checking height
                canActivate == true)
                {
                    correctNote = false;
                    canActivate = false;
                    interact();
                }
            }
            //musicTimer = 0f;
            notePlayed = false;
        }
    }

    void interact()
    {
        //Debug.Log("object order " + order);
        sequencePuzzle.interact(order, correctNote); // in here also the boolean for correct note
    }

    //Activated and correct
    public void activated()
    {
        myLight.intensity = 50;
        myLight.color = color1;
        activatedBool = true;
    }

    //React() is for reacting to the right note being played. but not the right order. 
    //Just some visual feedback for the player that this object contains the note the player just played.
    void react()
    {
        myLight.intensity = 50;
        myLight.color = color3;
        StartCoroutine(ExecuteAfterTime());

        IEnumerator ExecuteAfterTime()
        {
            yield return new WaitForSeconds(0.6f);
            if (activatedBool == false)
            {
                myLight.color = color1;
                myLight.intensity = 0;
            }
        }
    }


    //Reset pillar
    public void deactivate()
    {
        myLight.intensity = 20;
        myLight.color = color2;
        StartCoroutine(ExecuteAfterTime()); //Delay for giving red light (interactive feedback)

        IEnumerator ExecuteAfterTime()
        {
            yield return new WaitForSeconds(0.2f);
            myLight.color = color1;
            myLight.intensity = 0;
            canActivate = true;
            activatedBool = false;
        }
    }

    //Small reset mainly for the first pillar if you have it wrong.
    public void smallReset()
    {
        canActivate = true;
        activatedBool = false;
    }
}
