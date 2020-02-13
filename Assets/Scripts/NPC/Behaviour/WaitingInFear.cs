using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingInFear : StateMachineBehaviour
{
    public float waitTime = 2f;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            animator.SetBool("isWaitingInFear", false);
            animator.SetBool("isShocked", false);
            animator.SetBool("isWalking", true);
            animator.GetComponent<NPC>().isWaitingInFear = false;

            waitTime = 2f;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("turn");
    }
}
