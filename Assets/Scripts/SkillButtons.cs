using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtons : MonoBehaviour
{
    //public AudioSource a3;
    //public AudioSource b3;
    //public AudioSource c3;

    public GameObject[] skill;
    public AudioSource[] note;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            playNote();
        }
        */
    }

    public void playNote(int noteIndex)
    {
        note[noteIndex].Play();
    }

    public void playSkill(int skillIndex)
    {
        Instantiate(skill[skillIndex], transform.position, transform.rotation);
    }
}
