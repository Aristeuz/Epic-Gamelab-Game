using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtons : MonoBehaviour
{
    //Makes arrays that you can fill in, inside Unity.
    public GameObject[] skill;
    public AudioSource[] note;


    //This is for the notes, it only works as long as "makeshiftUI" is active in the scene.
    //I'm guessing it gets the actual notes from there, maybe we need to make a deticated note holder?
    public void playNote(int noteIndex)
    {
        note[noteIndex].Play();
    }

    //This is for an extra thing the "skill" can do, in this case it just spawns a ball.
    //Could not figure out how I could let them work both in the same function. So they are seperate.
    public void playSkill(int skillIndex)
    {
        Instantiate(skill[skillIndex], transform.position, transform.rotation);
    }
}
