using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteUnlocker : MonoBehaviour
{
    public _noteUnlockType noteUnlockType;
    public UImanager UImanager;
    public GameObject effect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (noteUnlockType == _noteUnlockType.One)
        {
            UImanager.unlockOne = true;
        }
        if (noteUnlockType == _noteUnlockType.Two)
        {
            UImanager.unlockTwo = true;
        }
        Instantiate(effect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
