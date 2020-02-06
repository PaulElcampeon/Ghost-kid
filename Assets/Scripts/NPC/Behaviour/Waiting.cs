using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting : StateMachineBehaviour
{
    public float waitTime = 2f;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            animator.GetComponent<NPC>().isWaiting = false;
            animator.SetBool("isWaiting", false);
            animator.SetBool("isWalking", true);
            waitTime = 2f;
        }
    }
}
