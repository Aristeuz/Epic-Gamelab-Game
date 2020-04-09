using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class moveEvent : MusicInteractable
{
    public Transform moveTo = null;
    public float moveSpeed;
    protected bool isMoving = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        if (moveTo == null)
            moveTo = this.gameObject.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (bardSong.Substring(bardSong.Length - solutionLength) == triggerSolution &&
            distanceToPlayerXZ <= activationRangeWidth && //Checking width
            Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight && //Checking height
            canActivate == true)
        {
            isMoving = true;
        }

        //makes it keep moving untill it reaches it's destenation
        if (isMoving == true)
        {
            slowlyMove();
        }
        if (transform.position == moveTo.position)
        {
            isMoving = false;
        }
    }

    //This one is activated via Sequence Puzzle
    public void activate()
    {
        isMoving = true;
        slowlyMove();
    }

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
}
