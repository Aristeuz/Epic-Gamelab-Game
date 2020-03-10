using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInteractable : MonoBehaviour
{
    public GameObject playerCollider;
    public string triggerSolution = "";
    private int solutionLength;
    private int bardSongLength;
    // Start is called before the first frame update
    void Start()
    {
        //Figure out how long the TriggerSolution is and record that.
        solutionLength = triggerSolution.Length;

        bardSongLength = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MusicRangeCollider")
        {
            if (playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Substring(bardSongLength - solutionLength) == triggerSolution) 
                                                        //https://answers.unity.com/questions/435275/get-the-last-four-characters-off-a-string.html
            {
                //open door
                
                Debug.Log("Door opening");

                //oof what a shitty door opening.
                this.gameObject.transform.position.z.Equals(-10);
            }
        }

                
    }
}
