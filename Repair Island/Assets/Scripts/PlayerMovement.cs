using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// try to play states through code in a future rendition
//https://docs.unity3d.com/ScriptReference/Animator.SetTrigger.html
//https://docs.unity3d.com/ScriptReference/Animator.GetCurrentAnimatorStateInfo.html


public class PlayerMovement : MonoBehaviour
{

    Vector3 leftRightMove;
    Vector3 upDownMove;
    public float walkspeed = 1.5f;
    public float runspeed = 6.0f;
    int whichAxis = 0; //0 not moving. 1 LR. 2 UD
    public bool canRun = false;

    public GameObject slashF, slashB, slashL, slashR;

    public bool axeEquiped = false;

    bool facingB, facingF, facingL, facingR = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetBool("canRun", canRun);

        //animator.SetTrigger("runR"); 


        if (Input.GetKey(KeyCode.Mouse0) && axeEquiped && (Input.GetAxis("Horizontal") > 0 || facingR == true)) //right swing 
        {
            facingB = false;
            facingF = false;
            facingL = false;
            facingR = true;
            slashB.GetComponent<SpriteRenderer>().enabled = false;
            slashF.GetComponent<SpriteRenderer>().enabled = false;
            slashL.GetComponent<SpriteRenderer>().enabled = false;
            slashR.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && axeEquiped && (Input.GetAxis("Horizontal") < 0 || facingL == true)) //left swing 
        {
            facingB = false;
            facingF = false;
            facingL = true;
            facingR = false;
            slashB.GetComponent<SpriteRenderer>().enabled = false;
            slashF.GetComponent<SpriteRenderer>().enabled = false;
            slashL.GetComponent<SpriteRenderer>().enabled = true;
            slashR.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && axeEquiped && (Input.GetAxis("Vertical") < 0 || facingF == true)) //Forward swing 
        {
            facingB = false;
            facingF = true;
            facingL = false;
            facingR = false;
            slashB.GetComponent<SpriteRenderer>().enabled = false;
            slashF.GetComponent<SpriteRenderer>().enabled = true;
            slashL.GetComponent<SpriteRenderer>().enabled = false;
            slashR.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && axeEquiped && (Input.GetAxis("Vertical") > 0 || facingB == true)) //back swing 
        {
            facingB = true;
            facingF = false;
            facingL = false;
            facingR = false;
            slashB.GetComponent<SpriteRenderer>().enabled = true;
            slashF.GetComponent<SpriteRenderer>().enabled = false;
            slashL.GetComponent<SpriteRenderer>().enabled = false;
            slashR.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if(!Input.GetKey(KeyCode.Mouse0))
        {
            facingB = false;
            facingF = false;
            facingL = false;
            facingR = false;
            slashB.GetComponent<SpriteRenderer>().enabled = false;
            slashF.GetComponent<SpriteRenderer>().enabled = false;
            slashL.GetComponent<SpriteRenderer>().enabled = false;
            slashR.GetComponent<SpriteRenderer>().enabled = false;
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
             canRun = true;
             walkspeed = 3.0f;
            //animator.SetTrigger("sprintR");
        }
        else
        {
            canRun = false;
            walkspeed = 1.5f;
        }


        leftRightMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position = transform.position + leftRightMove * Time.deltaTime * walkspeed;
        upDownMove = new Vector3(0, Input.GetAxis("Vertical"), 0);
        transform.position = transform.position + upDownMove * Time.deltaTime * walkspeed;





    }
}
