using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class DestroyEvent : MusicInteractable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
            destroySelf();
        }
    }

    //Destroys itself, there is also the posibility to instantiate an effect or another object before it is destroyed.
    void destroySelf()
    {
        //Debug.Log("OBJECT DESTROYED!");
        if (withShake == true)
            CameraShaker.Instance.ShakeOnce(1f, 4f, 0.5f, 0.1f);
        Destroy(this.gameObject);

    }
}
