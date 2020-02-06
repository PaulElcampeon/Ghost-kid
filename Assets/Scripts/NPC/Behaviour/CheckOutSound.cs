using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutSound : StateMachineBehaviour
{
    //NOT USING THIS CODE AT THE MOMENT
    private Vector3 positionToMoveTo;
    public bool positionToMoveToXAxisIsGreater;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        positionToMoveTo = animator.GetComponent<NPC>().itemThatJustMadeASound.transform.position;
        positionToMoveToXAxisIsGreater = positionToMoveTo.x > animator.GetComponent<Rigidbody2D>().transform.position.x;

        if (positionToMoveToXAxisIsGreater)
        {
            if(!animator.GetComponent<NPC>().isMovingRight)
            {
                animator.GetComponent<NPC>().Flip();
                animator.GetComponent<NPC>().isMovingRight = true;
            }
        } else
        {
            if (animator.GetComponent<NPC>().isMovingRight)
            {
                animator.GetComponent<NPC>().Flip();
                animator.GetComponent<NPC>().isMovingRight = false;
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NPC>().MoveToPosition(positionToMoveTo);
        if(animator.GetComponent<Rigidbody2D>().transform.position.x == positionToMoveTo.x)
        {
            animator.GetComponent<NPC>().isInspectingSound = false;
            animator.SetBool("checkOutSound", false);
            animator.GetComponent<NPC>().isWaiting = true;
            animator.SetBool("isWaiting", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
