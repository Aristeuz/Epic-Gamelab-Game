using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePuzzle : MonoBehaviour
{
    public int currentNumber = -1;
    float timer = 0;
    bool check = true;

    public DestroyEvent _destroyEvent;
    public activateAndGlowEvent _activateAndGlowEvent;
    public moveEvent _moveEvent;

    public List<SequencePuzzleObject> tag_targets = new List<SequencePuzzleObject>();

    void GetSequencePuzzleObjects() // put all children into the list;
    {
        tag_targets.Clear();
        foreach(SequencePuzzleObject puzzleObject in GetComponentsInChildren<SequencePuzzleObject>())
        {
            tag_targets.Add(puzzleObject);
            puzzleObject.sequencePuzzle = this;
        }
    }

    void Awake() //has to be awake. Not start
    {
        GetSequencePuzzleObjects();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
    }

    public void interact(int order, bool correctNote)
    {
        if (timer > 0.1) //Used when two Activation ranges overlap. 
        {
            //Debug.Log("Order " + order + " CurrentNumber " + (currentNumber + 1) + " Correct Note " +correctNote);
            if (currentNumber + 1 == order && correctNote == true)
            {
                Debug.Log(order + " GOOD");
                tag_targets[order].activated();
                currentNumber++;
                timer = 0;
            }
            else
            {
                //Activates "deactivate()" (red lights) only when you've passed the first note. (otherwise they keep bloinking)
                if (currentNumber != -1)
                {
                    Debug.Log(currentNumber + " WRONG");
                    foreach (SequencePuzzleObject puzzleObject in tag_targets)
                    {
                        puzzleObject.deactivate();
                    }
                }
                else
                {
                    tag_targets[order].smallReset();
                }
                currentNumber = -1;
                timer = 0;
            }
        }
        else
        {
            tag_targets[order].smallReset();
            //Debug.Log(currentNumber + "current number right after");
        }

        //if all pillars are correct activate whichever Event it is linked to.
        if (currentNumber == tag_targets.Count - 1)
        {
            Debug.Log("COMPLETE!");
            if (_destroyEvent != null)
                _destroyEvent.activate();
            if (_activateAndGlowEvent != null)
                _activateAndGlowEvent.activate();
            if (_moveEvent != null)
                _moveEvent.activate();
        }
    }
}
