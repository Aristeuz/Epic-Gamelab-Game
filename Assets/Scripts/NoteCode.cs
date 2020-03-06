using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NoteCode : MonoBehaviour
{
    public float speed;
    public Transform target; //This is the Note player
    public Transform backOfLine; //this will be the back of the line, to return the player to.
    private int loopcount = 0;
    public string assignedNote = " ";

    public AudioSource a3;
    public AudioSource b3;
    public AudioSource c3;
    public AudioSource d3;
    public AudioSource e3;
    public AudioSource f3;
    public AudioSource g3;


    void Start()
    {

    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
        //ugly test, since the collision isnt working for some dumb reason
        if (Vector3.Equals(target.position.x, this.transform.position.x))
        {
            //we go find what sound it assigned to this note and play it.
            switch (assignedNote)
            {
                case "a":
                //Debug.Log("Play audio A note.");
                a3.Play();
                break;
                case "b":
                //Debug.Log("Play audio B note.");
                b3.Play();
                break;
                case "c":
                //Debug.Log("Play audio C note.");
                c3.Play();
                break;
                case "d":
                //Debug.Log("Play audio D note.");
                d3.Play();
                break;
                case "e":
                //Debug.Log("Play audio E note.");
                e3.Play();
                break;
                case "f":
                //Debug.Log("Play audio F note.");
                f3.Play();
                break;
                case "g":
                //Debug.Log("Play audio G note.");
                g3.Play();
                break;
                case " ":
                //Debug.Log("empty note, no audio.");
                //no audio play.
                break;
            }
            //possible step. we then send the letter of the note to an array somewhere that is logging them looking for the right sequence. (a blank note means a space)
            // NOT DONE YET.

            //we then set this note to blank, so it has no note attached to it.
            assignedNote = " ";
            //Debug.Log("Blanking note");


            //we send it back to the back of the line
            this.transform.position = new Vector3(backOfLine.position.x, backOfLine.position.y, backOfLine.position.z);
                //then log the loop count
                loopcount++; //Debug.Log("Note exit from bar " + loopcount);
        }
    }
    
/* for some dumb reason I cant get the collision to work with this. so I'll just do it with an ugly if statment >.>

    void OnCollisionStay(Collision other)
    {
        Debug.Log("Annie are you working? are you working? Are you working annie?!");

        if (other.gameObject.name == "notePlayer")        //when this note colides with the Note player
        {
        //we go find what sound it assigned to this note and play it.
        //possible step. we then send the letter of the note to an array somewhere that is logging them looking for the right sequence. (a blank note means a space)
        //we then set this note to blank, so it has no note attached to it.
            //we send it back to the back of the line
            this.transform.position = new Vector3(backOfLine.position.x, backOfLine.position.y, backOfLine.position.z);
                //then log the loop count
                loopcount++;
                Debug.Log("Collision exit from bar " + loopcount);
        }

    }
*/

}
