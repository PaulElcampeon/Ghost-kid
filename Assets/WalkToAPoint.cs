using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToAPoint : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float xPos = animator.GetComponent<NPC>().missionCompleteAreaXPosition;
        if (xPos > animator.GetComponent<Rigidbody2D>().transform.position.x)
        {
            if(!animator.GetComponent<NPC>().isMovingRight)
            {
                animator.GetComponent<NPC>().isMovingRight = true;
                animator.GetComponent<NPC>().Flip();
            }
        } else
        {
            if (animator.GetComponent<NPC>().isMovingRight)
            {
                animator.GetComponent<NPC>().isMovingRight = false;
                animator.GetComponent<NPC>().Flip();
            }
        }
        animator.GetComponent<NPC>().MoveToPositionWalking(new Vector3(xPos, animator.GetComponent<NPC>().transform.position.y, animator.GetComponent<NPC>().transform.position.z));

        if(animator.GetComponent<Rigidbody2D>().transform.position.x == xPos)
        {
            animator.SetBool("missionComplete", true);
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
