using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToMove : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController controller;
    private Vector3 position;
    int layer_ground;
    int layer_UI;

    public Animator animator;
    [HideInInspector]
    public bool walking = false;

    int layerMask = 1 << 8;
    // Start is called before the first frame update
    void Start()
    {
        layer_ground = LayerMask.GetMask("Ground");
        layer_UI = LayerMask.GetMask("UI");
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walking", walking);

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            //Locate where the player clicked on the terrain
            locatePosition();
        }
        //Move the player to the position
        moveToPosition();
    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            //If it hits the Ground go there.
            if (hit.collider.tag == "Ground")
            {
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                //Debug.Log(position);
            }
        }
    }

    void moveToPosition()
    {
        if (Vector3.Distance(transform.position, position)>1) {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);

            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * moveSpeed);

            walking = true;
        }
        else
        {
            walking = false;
        }
    }
}
