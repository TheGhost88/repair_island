using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 leftRightMove;
    Vector3 upDownMove;
    public float walkspeed = 10.0f;
    public float runspeed = 40.0f;
    int whichAxis = 0; //0 not moving. 1 LR. 2 UD

    public Animator animator;

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));


        leftRightMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position = transform.position + leftRightMove * Time.deltaTime;
        upDownMove = new Vector3(0, Input.GetAxis("Vertical") * walkspeed, 0);


    }
}
