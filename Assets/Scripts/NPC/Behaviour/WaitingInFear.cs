using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingInFear : StateMachineBehaviour
{
    public float waitTime = 2f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            animator.GetComponent<NPC>().isWaitingInFear = false;
            animator.SetBool("isWaitingInFear", false);
            animator.SetBool("isShocked", false);
            animator.SetBool("isWalking", true);
            waitTime = 2f;
        }
    }
}
