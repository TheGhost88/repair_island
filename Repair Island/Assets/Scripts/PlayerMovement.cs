using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 leftRightMove;
    Vector3 upDownMove;
    public float walkspeed = 3.0f;
    public float runspeed = 6.0f;
    int whichAxis = 0; //0 not moving. 1 LR. 2 UD
    public bool canRun = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetBool("canRun", canRun);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            canRun = true;
            walkspeed = 6.0f;
        }
        else
        {
            canRun = false;
            walkspeed = 3.0f;
        }

       
            leftRightMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position = transform.position + leftRightMove * Time.deltaTime * walkspeed;
            upDownMove = new Vector3(0, Input.GetAxis("Vertical"), 0);
            transform.position = transform.position + upDownMove * Time.deltaTime * walkspeed;
       

        


    }
}
