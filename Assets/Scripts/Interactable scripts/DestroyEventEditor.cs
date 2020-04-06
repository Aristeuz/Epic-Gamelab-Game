﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

//The editor for the music interacables, it doesn't have to be attatched to anything.
//Now it only visualizes the range for us programmers
[CustomEditor(typeof(DestroyEvent))]
public class DestroyEventEditor : Editor
{
    void OnSceneGUI()
    {
        DestroyEvent interactable = (DestroyEvent)target;
        Handles.color = Color.cyan;
        Handles.DrawWireArc(interactable.transform.position, Vector3.up, Vector3.forward, 360, interactable.activationRangeWidth);
        Handles.DrawWireArc(interactable.transform.position + Vector3.up * interactable.activationRangeHeight, Vector3.up, Vector3.forward, 360, interactable.activationRangeWidth);
        Handles.DrawWireArc(interactable.transform.position - Vector3.up * interactable.activationRangeHeight, Vector3.up, Vector3.forward, 360, interactable.activationRangeWidth);
    }
}
#endif