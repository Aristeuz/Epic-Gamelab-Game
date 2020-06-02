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
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Horizontal and vertical movement
        moveHL = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        moveVL = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

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
