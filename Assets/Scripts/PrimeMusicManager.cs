using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


/* welcome to the Prime Music Manager, this code basically tracks the notes played and if the player is colliding with scenery objects that might make sounds.
 * It may in the future also hold the players ability to play notes other than envoirmental, but for now those are elsewhere, I imagine in the UI. Any questions, ask Ray
 * What might be important to note too, this also holds the brokenChain function, which spawns a particle when the player doesnt correctly follows the clues.
 */

public class PrimeMusicManager : MonoBehaviour
{

    public string bardSong = "                "; //starting state is 16 blanks. (this can be increased or decreased depending on the amount we wish to track.
    public string currentNote = " ";
    public float musicTimer = 0;
    public float musicalInterval = 2f; //this would also be how long a note lasts. This would not support phrases yet. since we havent build a system for doing those yet. maybe they disable the other system for a while? a state machine?


    private float bpm = 80f;
    private float convertedBPM = 0f;
    private float reactionTime = 0f;

    public GameObject particleA;
    public GameObject particleB;
    public GameObject particleC;
    public GameObject particleD;

    //public Collider playerCollider; we should probebly just add this to the player and then direct this to the bubble..
    public Collider MusicRangeCollider; //Not sure if we need to add this~

    public AudioSource a3;
    public AudioSource b3;
    public AudioSource c3;
    public AudioSource d3;
    public AudioSource e3;
    public AudioSource f3;
    public AudioSource g3;


    void Start()
    {
        convertedBPM = (1/(bpm/60)); //calculating how many beats per minute there are
        Debug.Log("Converted is equal to: " + convertedBPM);

        //calculate the extra reaction time after the beat to be a quarter over the total amount
        reactionTime = (convertedBPM / 4);
    }

    void FixedUpdate()
    {
        //A timer that constantly goes up.
            musicTimer += Time.deltaTime;
        //__________________________________________________________________________________________________________________
        //This first check is if we allow the player to play music too quick and then have it possibly go too fast.
        //This can be turned into an 8th beat by setting up a second string list that records these too quick beats and thus wont disturb the first list.
        //we check essentially if the player is playing too fast and thus goes off beat. (this does not currently support 8th notes, and likely never will. but could if needed)
 
        /*
        if (musicTimer < musicalInterval)
            {
                //check if the note is blank. otherwise the player is off beat
                if (currentNote != " ")
            {
                BrokenChain();
                Debug.Log("Chain broken, Too quick.");
                //remove the first letter of bardSong
                bardSong.Remove(0, 1);
                //add a - at the end of bardSong
                bardSong += "-"; // - will be a non note. b
                musicTimer = 0;
            }
        }
        */
            //________________________________________________________________________________________________________________
        
            //check if a note is played within the reaction time frame and not outside of it.
        if ((currentNote != " ") && (musicTimer <= convertedBPM + reactionTime) && (musicTimer >= convertedBPM))
        {
            //Play said note
                //I imagine we create a seperate void that we call here that will play the correct note according to a switch statement.
            //remove the first letter of the string, add the note in question to the end of the string.
            bardSong.Remove(0, 1);
                bardSong += currentNote; 
                Debug.Log("Current list = " + bardSong);
            playNotes();
            currentNote = " ";
            musicTimer = 0;
        }

        //we check if the player missed the reactionTime frame
        else if (musicTimer >= (convertedBPM + reactionTime))
        {
            //remove the first letter of bardSong
            //add a blankNote at the end of bardSong
            bardSong.Remove(0, 1);
            bardSong += currentNote;
            musicTimer = reactionTime; //(we're compensating for the time we acounted for reaction time. wether to take the full reaction time or only a bit I'm not sure. playtesting req.
        }
    }

    //Here we check to play the sound of an envoirment object.
    private void OnTriggerEnter(Collider other)
    {
        //Collider playerCollider = other.contacts[0].thisCollider; //This should allow the playerCollider to work as the colliding object

        //Debug.Log(other.gameObject.name);

        if (other.tag == "SoundTrigger")        //when this note colides with the Note player
        {
            if (other.gameObject.GetComponent<musicObjectCode>())
            {
                if (other.gameObject.GetComponent<musicObjectCode>().enabled == true) // checks if this script even exists in the object
                {
                    switch (other.gameObject.GetComponent<musicObjectCode>().assignedNote)
                    {
                        case "1": //The tutorial bell
                        //Debug.Log("The tutorial bell was rung.");
                        //set currentNote to the note in question
                        currentNote = "1";
                        break;

                        case "a": 
                        currentNote = "a";
                        break;

                        case "b": 
                        currentNote = "b";
                        break;

                        case " ":
                        //Debug.Log("empty note, no audio.");
                        currentNote = " ";
                        //This is an exception case. Not sure when it would be needed.

                        break;
                    }
                }

            }
        }

    }

    void playNotes()
    {
        switch (currentNote)
        {
            case "a":
            //Debug.Log("Play audio A note.");
            a3.Play();
            Instantiate(particleA, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            break;

            case "b":
            //Debug.Log("Play audio B note.");
            b3.Play();
            Instantiate(particleB, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            break;

            case "c":
            //Debug.Log("Play audio C note.");
            c3.Play();
            Instantiate(particleC, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            break;

            case "d":
            //Debug.Log("Play audio D note.");
            d3.Play();
            Instantiate(particleD, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            break;

            case "e":
            //Debug.Log("Play audio E note.");
            e3.Play();
            Instantiate(particleA, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            break;

            case "f":
            //Debug.Log("Play audio F note.");
            f3.Play();
            Instantiate(particleA, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            break;

            case "1":
            //Debug.Log("Play audio tutorial bell note.");
            g3.Play();
            Instantiate(particleA, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(2f, 6f, 0.5f, 2f);//Camerashake for this note.
            break;

            case " ":
            //Debug.Log("empty note, no audio.");
            //no audio play.
            break;
        }
    }

    void BrokenChain()
    {
        
        //This can be called by any enemy who's checking in with the bardSong. 
        //If after 2 or more succesfull following notes there is a wrong link in the end of the string, a particle will play. this is not tracked by BrokenChain. just making a note temporarily
    }

}
