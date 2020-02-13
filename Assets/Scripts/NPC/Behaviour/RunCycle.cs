using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCycle : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isShocked", false);
        animator.SetBool("isWaiting", false);
        animator.SetBool("isWaitingInFear", false);
        animator.ResetTrigger("turn");

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NPC>().RunAwayFromPlayer();
    }
}
