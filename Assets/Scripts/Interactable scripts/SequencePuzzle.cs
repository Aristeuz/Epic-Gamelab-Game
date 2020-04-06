using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePuzzle : MonoBehaviour
{
    public int currentNumber = -1;

    public List<SequencePuzzleObject> tag_targets = new List<SequencePuzzleObject>();

    void GetSequencePuzzleObjects() // put all children into the list;
    {
        tag_targets.Clear();
        foreach(SequencePuzzleObject puzzleObject in GetComponentsInChildren<SequencePuzzleObject>())
        {
            tag_targets.Add(puzzleObject);
            puzzleObject.sequencePuzzle = this;
        }

        //find all <SequencePuzzleObject>  in children
        //<SequencePuzzleObject>  
        //SequencePuzzleObject.sequencePuzzle = this;
    }

    void Awake() //has to be awake. Not start
    {
        GetSequencePuzzleObjects();
    }

    //It checks it sorta correctly, but there is no reset, it's not smooth. 
    public void interact(int order, bool correctNote)
    {
        //Debug.Log(order + " " + correctNote);
        if (currentNumber + 1 == order && correctNote == true)
        {
            Debug.Log(order + " GOOD");
            //Light turns on
            tag_targets[order].activated();
            currentNumber++;
        }
        else
        {
            Debug.Log(order + " WRONG");
            foreach(SequencePuzzleObject puzzleObject in tag_targets)
            {
                puzzleObject.deactivate();
            }
            currentNumber = -1;
            //All lights turn off.
            //restart.
            //can activate becomes true again for all
        }

        if (currentNumber == tag_targets.Count - 1)//if all are correct
        {
            Debug.Log("COMPLETE!");
        }
    }
}
