using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NPC>().isTurning = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NPC>().isMovingRight = !animator.GetComponent<NPC>().isMovingRight;
        animator.GetComponent<NPC>().Flip();
        animator.GetComponent<NPC>().isTurning = false;
    }
}
