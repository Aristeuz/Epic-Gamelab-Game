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

    private Transform firstChild;
    private Light myLight;
    Color color1 = Color.white;

    [Range(0, 10)]
    public float activationRange = 5f;

    //Eveything between ~~~~~~ is from PrimeMusicManager copypasted, could be made smoother with a connection.
    //It is only used for the bpm time in this case.
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private float musicTimer = 0;

    private float bpm = 80f;
    private float convertedBPM = 0f;
    private float reactionTime = 0f;
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    
    //Eveything between ======= is from MusicInteractable copypasted, could be made smoother with a connection.
    //==============================================================================================================

    //==============================================================================================================
    

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        firstChild = this.gameObject.transform.GetChild(0);
        myLight = firstChild.GetComponent<Light>();

        //~~~~~~~~~~~~~~~~~~~~~~~~~~
        convertedBPM = (1 / (bpm / 60));
        reactionTime = (convertedBPM / 4);
        //~~~~~~~~~~~~~~~~~~~~~~~~~
    }

    // Update is called once per frame

     protected override void Update()
    {
        base.Update();
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        musicTimer += Time.deltaTime;
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        float dist = Vector3.Distance(player.transform.position, transform.position);


        if (musicTimer >= convertedBPM + reactionTime)   
        {
            //Debug.Log("Current list = " + bardSong);
            //Should not listen to what is on the list but to what the player played last. If we want it to 'feel' better for the player. We should look into the timing condition.
            if (bardSong.Substring(bardSong.Length - solutionLength) == triggerSolution && // if note is correct.
            dist <= activationRange && //if player is close enough
            canActivate == true)
            {
                correctNote = true;
                canActivate = false;
                interact();
            }
            else if (bardSong.Substring(bardSong.Length - solutionLength) != triggerSolution && // if note is incorrect.
            dist <= activationRange &&
            canActivate == true)
            {
                correctNote = false;
                canActivate = false;
                interact();
            }
            musicTimer = 0;
        }
    }

    void interact()
    {
        sequencePuzzle.interact(order, correctNote); // in here also the boolean for correct note
    }

    public void activated()
    {
        myLight.intensity = 20;
        myLight.color = color1;
    }

    public void deactivate()
    {
        myLight.intensity = 0;
        canActivate = true;
    }
}
