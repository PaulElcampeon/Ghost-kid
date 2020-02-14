using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToAPoint : StateMachineBehaviour
{
    private float minXPos;
    private float maxXPos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        minXPos = animator.GetComponent<NPC>().missionCompleteZone.minXpos;
        maxXPos = animator.GetComponent<NPC>().missionCompleteZone.maxXPos;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isWaitingInFear", false);
        animator.SetBool("isWaiting", false);
        animator.SetBool("isRunning", false);
        animator.ResetTrigger("turn");

        float npcXPos = animator.GetComponent<Rigidbody2D>().transform.position.x;

        if (minXPos > npcXPos)
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
        animator.GetComponent<NPC>().MoveToPositionWalking(new Vector3(minXPos, animator.GetComponent<NPC>().transform.position.y, animator.GetComponent<NPC>().transform.position.z));

        if(npcXPos >= minXPos && npcXPos <= maxXPos)
        {
            animator.GetComponent<NPC>().heartParticles.SetActive(true);
            animator.SetBool("waitngForGameToEnd", true);
        }
    }
}
