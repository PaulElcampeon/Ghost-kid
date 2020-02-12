using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shocked : StateMachineBehaviour
{
    private float delayTime = 0.7f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NPC>().PlayScreamAudio();
        GameManager.instance.IncreaseFreakOMeter();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        delayTime -= Time.deltaTime;

        if (delayTime <= 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("checkOutSound", false);
            animator.SetBool("isWaiting", false);
            animator.SetBool("isWaitingInFear", false);
            animator.SetBool("isShocked", false);
            animator.SetBool("isRunning", true);
        }
    }
}
