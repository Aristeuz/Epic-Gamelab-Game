using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* welcome to the Prime Music Manager, this code basically tracks the notes played and if the player is colliding with scenery objects that might make sounds.
 * It may in the future also hold the players ability to play notes other than envoirmental, but for now those are elsewhere, I imagine in the UI. Any questions, ask Ray
 * What might be important to note too, this also holds the brokenChain function, which spawns a particle when the player doesnt correctly follows the clues.
 */

public class PrimeMusicManager : MonoBehaviour
{

    public string bardSong = "        "; //starting state is 8 blanks. (this can be increased or decreased depending on the amount we wish to track.
    public string currentNote = " ";
    public float musicTimer = 0;
    public float musicalInterval = 2; //this would also be how long a note lasts. This would not support phrases yet. since we havent build a system for doing those yet. maybe they disable the other system for a while? a state machine?
    public float reactionTime = 0.5f;

    public AudioSource a3;
    public AudioSource b3;
    public AudioSource c3;
    public AudioSource d3;
    public AudioSource e3;
    public AudioSource f3;
    public AudioSource g3;



    // Start is called before the first frame update
    void Start()
    {
        //nothing for now. but I'm sure we'll use this sooner or later.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //A timer that constantly goes up.
            musicTimer += Time.deltaTime;

        //we check essentially if the player is playing too fast and thus goes off beat. (this does not currently support 8th notes, and likely never will. but could if needed)
            if (musicTimer < musicalInterval)
            {
                //check if the note is blank. otherwise the player is off beat
                if (currentNote != " ")
            {
                BrokenChain();
                Debug.Log("Chain broken, Too quick.");

                //remove the first letter of bardSong
                //add a - at the end of bardSong
            }

            // set timer to 0
        }

            //check if a note is played within the reaction time frame and not outside of it.
        if ((currentNote != " ") && (musicTimer <= musicalInterval + reactionTime) && (musicTimer >= musicalInterval))
        {
            //A check after interval X about if a note has been added
            //If so
            //Play said note
            //remove the first letter of the string, add the note in question to the end of the string.

            //If instead the note is blank.
            //No music is played
            //remove the first letter of the string, and add a blank note to the end of the string.

            //Set timer to 0.
        }

        //we check if the player missed the reactionTime frame
        else if (musicTimer >= (musicalInterval + reactionTime))
        {
            //remove the first letter of bardSong
            //add a blankNote at the end of bardSong
            musicTimer = (reactionTime / 2); //(we're compensating for the time we acounted for reaction time. wether to take the full reaction time or only a bit I'm not sure. playtesting req.

        }






    }

    //Here we check to play the sound of an envoirment object. 
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Annie are you working? are you working? Are you working annie?!");

        if (other.gameObject.tag == "SoundTrigger")        //when this note colides with the Note player
        {
            /*
            switch (// Here we add a string from the trigger object. but it hasnt been written yet *)
            {
                case "a note": //regular example
                //Debug.Log("Play audio 'a note'.");
                //set currentNote to the note in question
                break;

                case " ":
                //Debug.Log("empty note, no audio.");
                //set currentNote to blank.
                //This is an exception case. Not sure when it would be needed.

                break;
            }
            */
        }

    }

    void BrokenChain()
    {
        
        //This can be called by any enemy who's checking in with the bardSong. 
        
        //If after 2 or more succesfull following notes there is a wrong link in the end of the string, a particle will play. this is not tracked by BrokenChain. just making a note temporarily
    }

}
