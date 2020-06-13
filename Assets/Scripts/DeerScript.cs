using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeerScript : MonoBehaviour
{
    private NavMeshAgent navMesh;

    public GameObject Player;
    public Animator animator;


    public PrimeMusicManager primeMusicManager;

    public float runRange = 10.0f;
    public float runSpeed = 10;
    public float vibeMeterLimit = 2;
    [HideInInspector]
    public bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = runSpeed;
        navMesh.acceleration = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("run", run);
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //Run away
        if (distance < runRange)
        {
            //If the vibemeter from Prime Music Manager is not high enough. Run away.
            if (primeMusicManager.vibeMeter < vibeMeterLimit)
            {
                Vector3 targetDirection = transform.position - Player.transform.position;

                Vector3 newPos = transform.position + targetDirection;

                navMesh.SetDestination(newPos);
                run = true;
            }
        }
        else
        {
            run = false;
        }
    }
}
