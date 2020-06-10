using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTurn : MonoBehaviour
{
    public float rotateVariable = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, rotateVariable * Time.deltaTime, 0.0f, Space.World);
    }
}
