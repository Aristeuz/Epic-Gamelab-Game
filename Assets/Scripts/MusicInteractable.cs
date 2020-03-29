using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class MusicInteractable : MonoBehaviour
{
    public GameObject playerCollider;
    private GameObject player;
    private Transform playerLocation;
    public string triggerSolution = "";
    private int solutionLength;
    private int bardSongLength;

    private string bardSong;

    [Range(0, 100)]
    public float activationRangeWidth = 20f;
    [Range(0, 20)]
    public float activationRangeHeight = 5f;
    //====Everything that has to do with what can happen after "activation"====
    public _actionType actionType; //Connected with the Enums script.
    private bool canActivate = true;


    //target to where it moves to and how fast.
    public Transform moveTo = null;
    public float moveSpeed;
    public bool withShake = true;
    private bool isMoving = false;

    //For spawning in the glow object
    public GameObject glowObject;
    //==========================================================================

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerLocation = player.transform;

        //If the target is empty find itself so it doesn't cause an error.
        if (moveTo == null)
            moveTo = this.gameObject.transform; //.GetChild(0); (if it has to look for child?)

        //Figure out how long the TriggerSolution is and record that.
        solutionLength = triggerSolution.Length;
        bardSongLength = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Length;

        bardSong = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong;

        //If it is set to glow, deactivate the "musicObjectCode", so it can be activated later, once the player plays the right note first.
        if (actionType == _actionType.glow)
        {
            if (GetComponent<musicObjectCode>())
                GetComponent<musicObjectCode>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("LastFew " + bardSong.Substring(bardSong.Length - solutionLength));
        //Updates the current bardsong.
        bardSong = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Substring(bardSong.Length - solutionLength);

        float distanceToPlayerXZ = transform.position.FlatDistanceTo(playerLocation.position); //find distance between player and object X axis and Z axis.

        if (bardSong.Substring(bardSong.Length - solutionLength) == triggerSolution && 
            distanceToPlayerXZ <= activationRangeWidth && //Checking width
            Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight && //Checking height
            canActivate == true)
        {
            //Checks what "action" has been selected for this object.
            if (actionType == _actionType.destroySelf)
            {
                destroySelf();
            }
            else if (actionType == _actionType.move)
            {
                isMoving = true;
            }
            else if (actionType == _actionType.glow)
            {
                startGlow();
            }
        }

        //====Makes it keep moving and stop when it reaches it's end point====
        if (isMoving == true)
        {
            slowlyMove();
        }
        if (transform.position == moveTo.position)
        {
            isMoving = false;
        }
        //=====================================================================
    }

    //Makes the object move to a certain location, with a certain speed within the time of the next beat.
    //Disables the object afterwards so it is not able to move anymore.
    void slowlyMove()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTo.position, step);

        //Makes sure that you can't activate it once it has been activated.
        StartCoroutine(ExecuteAfterTime(1));
        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(0.1f);
            //Debug.Log("OPEN THE GATE!");
            if (withShake == true)
                CameraShaker.Instance.ShakeOnce(0.3f, 4f, 0.5f, 0.1f);
            if (canActivate == true)
                canActivate = false;
        }
    }

    //Destroys itself, there is also the posibility to instantiate an effect or another object before it is destroyed.
    void destroySelf()
    {
        //Debug.Log("OBJECT DESTROYED!");
        Destroy(this.gameObject);
    }

    //Starts glowing (IF THE GLOW ACTION IS SELECTED IT AUTOMATICALLY DISABLES THE MUSIC OBJECT CODE UNTILL THE RIGHT NOTE IS PLAYED)
    void startGlow()
    {
        Debug.Log("GLOW!");
        if (GetComponent<musicObjectCode>()) //Just checking if this script excists, then activates it.
        {
            Instantiate(glowObject, transform.position, transform.rotation);
            GetComponent<musicObjectCode>().enabled = true;
            canActivate = false;
        }
    }
}
