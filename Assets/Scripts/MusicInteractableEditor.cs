using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//The editor for the music interacables, it doesn't have to be attatched to anything.
//Now it only visualizes the range for us programmers
[CustomEditor(typeof(MusicInteractable))]
public class MusicInteractableEditor : Editor
{
    private void OnSceneGUI()
    {
        MusicInteractable interactable = (MusicInteractable)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(interactable.transform.position, Vector3.up, Vector3.forward, 360, interactable.activationRange);
    }
}
