using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePuzzleObject : MusicInteractable
{
    [HideInInspector]
    public SequencePuzzle sequencePuzzle;
    public int order = 0;
    private bool correctNote = false;
    int correctnumber;

    private Transform firstChild;
    private Light myLight;
    Color color1 = Color.white;
    Color color2 = Color.red;

    //[Range(0, 10)]
    //public float activationRange = 5f;

    //Eveything between ~~~~~~ is from PrimeMusicManager copypasted, could be made smoother with a connection.
    //It is only used for the bpm time in this case.
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private float musicTimer = 0;

    private float bpm = 80f;
    private float convertedBPM = 0f;
    private float reactionTime = 0f;
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        firstChild = this.gameObject.transform.GetChild(0);
        myLight = firstChild.GetComponent<Light>();

        //~~~~~~~~~~~~~~~~~~~~~~~~~~
        convertedBPM = (1 / (bpm / 60));
        reactionTime = (convertedBPM / 4);
        //~~~~~~~~~~~~~~~~~~~~~~~~~
    }

    // Update is called once per frame

     protected override void Update()
    {
        base.Update();
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        musicTimer += Time.deltaTime;
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        float dist = Vector3.Distance(player.transform.position, transform.position);

        
        if (distanceToPlayerXZ <= activationRangeWidth && //Checking width
            Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight //Checking height
            )
        {
            //Debug.Log(musicTimer);
        }
        

        if (musicTimer >= convertedBPM + reactionTime + 0.1f) //The 0.1 gives a little delay before checking  
        {
            //Debug.Log(this.gameObject.name + " CHECK! " + canActivate);
            //Debug.Log(this.gameObject.name + " " + canActivate);
            //Debug.Log("Current list = " + bardSong);
            //Should not listen to what is on the list but to what the player played last. If we want it to 'feel' better for the player. We should look into the timing condition.
            if (bardSong.Substring(bardSong.Length - solutionLength) == triggerSolution && // if note is correct.
            distanceToPlayerXZ <= activationRangeWidth && //Checking width
            Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight && //Checking height
            canActivate == true)
            {
                correctNote = true;
                canActivate = false;
                interact();
            }
            else if (bardSong.Substring(bardSong.Length - solutionLength) != triggerSolution && // if note is incorrect.
            distanceToPlayerXZ <= activationRangeWidth && //Checking width
            Mathf.Abs((playerLocation.position - transform.position).y) <= activationRangeHeight && //Checking height
            canActivate == true)
            {
                correctNote = false;
                canActivate = false;
                interact();
            }
            musicTimer = 0.1f;
        }
    }

    void interact()
    {
        sequencePuzzle.interact(order, correctNote); // in here also the boolean for correct note
    }

    public void activated()
    {
        myLight.intensity = 20;
        myLight.color = color1;
    }

    public void deactivate()
    {
        myLight.intensity = 20;
        myLight.color = color2;
        StartCoroutine(ExecuteAfterTime()); //Delay for giving red light (interactive feedback)

        IEnumerator ExecuteAfterTime()
        {
            yield return new WaitForSeconds(0.2f);
            myLight.color = color1;
            myLight.intensity = 0;
            canActivate = true;
        }
    }

    public void smallReset()
    {
        canActivate = true;
    }
}
