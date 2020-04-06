using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class MusicInteractable : MonoBehaviour
{
    public GameObject playerCollider;
    protected Transform playerLocation;
    public string triggerSolution = "";
    protected GameObject player;
    protected int solutionLength;

    protected int bardSongLength;
    protected string bardSong;

    protected float distanceToPlayerXZ;

    [Range(0, 100)]
    public float activationRangeWidth = 20f;
    [Range(0, 20)]
    public float activationRangeHeight = 5f;


    protected bool canActivate = true;
    public bool withShake = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Debug.Log("START");
        player = GameObject.Find("Player");
        playerLocation = player.transform;

        //Figure out how long the TriggerSolution is and record that.
        solutionLength = triggerSolution.Length;
        bardSongLength = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Length;

        bardSong = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Debug.Log("Current list = " + bardSong);
        //Debug.Log("LastFew " + bardSong.Substring(bardSong.Length - solutionLength));

        //Updates the current bardsong.
        bardSong = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Substring(bardSong.Length - solutionLength);
        //find distance between player and object X axis and Z axis.
        float distanceToPlayerXZ = transform.position.FlatDistanceTo(playerLocation.position);

    }
}

