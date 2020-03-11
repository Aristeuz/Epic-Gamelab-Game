using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInteractable : MonoBehaviour
{
    public GameObject playerCollider;
    public string triggerSolution = "";
    private int solutionLength;
    private int bardSongLength;

    private string bardSong;
    // Start is called before the first frame update
    void Start()
    {
        //Figure out how long the TriggerSolution is and record that.
        solutionLength = triggerSolution.Length;
        bardSongLength = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Length;

        bardSong = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong;
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the current bardsong.
        bardSong = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Substring(bardSongLength - solutionLength);
        //Debug.Log("LastFew " + bardSong.Substring(bardSongLength - solutionLength));

        if (bardSong.Substring(bardSongLength - solutionLength) == triggerSolution)
        {
            Debug.Log("OPEN THE GATE!");
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
    }
}
