using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class extensions
{
    //This is for MusicInteractable so it only measures distance in the width (x and z)
    public static Vector2 xz(this Vector3 vv)
    {
        return new Vector2(vv.x, vv.z);
    }

    public static float FlatDistanceTo(this Vector3 from, Vector3 unto)
    {
        Vector2 a = from.xz();
        Vector2 b = unto.xz();
        return Vector2.Distance(a, b);
    }
}
