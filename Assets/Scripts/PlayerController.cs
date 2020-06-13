using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 9.0f;
    public float rotateSpeed = 10f;
    //public Transform relativeTransform;
    float moveHL, moveVL = 0;

    public Animator animator;
    [HideInInspector]
    public bool walking = false;

    //private Rigidbody rb;
    private CharacterController CC;

    private Vector3 direction;

    private void Awake()
    {
        CC = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walking", walking);
        //Horizontal and vertical movement
        moveHL = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        moveVL = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        //For animation
        if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Horizontal") < -0.1 || Input.GetAxis("Vertical") < -0.1)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }


            //Look direction
            direction = new Vector3(moveHL, 0f, -moveVL);
        CC.SimpleMove(direction * movementSpeed * 6);
       
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            //transform.LookAt(transform.position + direction);
        }
        
    }

}
