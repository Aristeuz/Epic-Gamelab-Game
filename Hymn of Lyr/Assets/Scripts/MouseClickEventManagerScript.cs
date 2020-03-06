using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickEventManagerScript : MonoBehaviour
{
    public AudioSource a3;
    public AudioSource b3;
    public AudioSource c3;
    public AudioSource d3;
    public AudioSource e3;
    public AudioSource f3;
    public AudioSource g3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitNote;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitNote)) // switch with multiple checks
            {
                switch (hitNote.transform.name) { //just a check for which object is tapped. if its a note block it'll play it.
                    case "NoteblockA":
                    { print("Noteblock A is clicked by mouse");
                      a3.Play();}
                    break;
                    case "NoteblockB":
                    { print("Noteblock B is clicked by mouse");
                      b3.Play();
                    }
                    break;
                    case "NoteblockC":
                    { print("Noteblock C is clicked by mouse");
                      c3.Play();
                    }
                    break;
                    case "NoteblockD":
                    { print("Noteblock D is clicked by mouse");
                      d3.Play();
                    }
                    break;
                    case "NoteblockE":
                    { print("Noteblock E is clicked by mouse");
                      e3.Play();
                    }
                    break;
                    case "NoteblockF":
                    { print("Noteblock F is clicked by mouse");
                      f3.Play();
                    }
                    break;
                    case "NoteblockG":
                    { print("Noteblock G is clicked by mouse");
                      g3.Play();
                    }
                    break;
                }

            }
        }
    }
}

