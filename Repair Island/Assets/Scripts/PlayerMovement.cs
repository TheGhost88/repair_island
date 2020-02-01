using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 leftRightMove;
    Vector3 upDownMove;
    public float walkspeed = 1.2f;
    public float runspeed = 2.0f;
    int whichAxis = 0; //0 not moving. 1 LR. 2 UD
    public bool canRun = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift))
        {
            canRun = true;
        }
        else
        {
            canRun = false;
        }

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        animator.SetBool("canSprint", canRun);


        leftRightMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        upDownMove = new Vector3(0, Input.GetAxis("Vertical"), 0);

        if (canRun)
        {
            transform.position = transform.position + leftRightMove * Time.deltaTime * runspeed;

            transform.position = transform.position + upDownMove * Time.deltaTime * runspeed;
        }
        else
        {
            transform.position = transform.position + leftRightMove * Time.deltaTime * walkspeed;

            transform.position = transform.position + upDownMove * Time.deltaTime * walkspeed;
        }
       

    }
}
