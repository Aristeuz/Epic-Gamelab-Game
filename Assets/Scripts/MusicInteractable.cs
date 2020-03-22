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
    public float activationRange = 20f;

    //====Everything that has to do with what can happen after "activation"====
    public _actionType actionType; //Connected with the Enums script.
    private bool canActivate = true;


    //target to where it moves to and how fast.
    public Transform moveTo = null;
    public float moveSpeed;
    public bool withShake = true;
    private bool isMoving = false;
    //==========================================================================

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerLocation = player.transform;

        //If the target is empty find it's child targetlocation.
        if (moveTo == null)
            moveTo = this.gameObject.transform; //.GetChild(0);



        //Figure out how long the TriggerSolution is and record that.
        solutionLength = triggerSolution.Length;
        bardSongLength = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Length;

        bardSong = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("LastFew " + bardSong.Substring(bardSong.Length - solutionLength));
        //Updates the current bardsong.
        bardSong = playerCollider.gameObject.GetComponent<PrimeMusicManager>().bardSong.Substring(bardSong.Length - solutionLength);

        float distdistanceToPlayer = Vector3.Distance(playerLocation.position, transform.position);//find distance between player and object, so it can only activate within a certain range.

        if (bardSong.Substring(bardSong.Length - solutionLength) == triggerSolution && distdistanceToPlayer < activationRange && canActivate == true)
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
        Debug.Log("OPEN THE GATE!");
        Destroy(this.gameObject);
    }
}
