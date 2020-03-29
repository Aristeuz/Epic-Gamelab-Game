using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    public float aliveTime = 2;
    private float timer = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        timer += 1 * Time.deltaTime;
        if (timer >= aliveTime)
            Destroy(this.gameObject);
    }
}
