using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessAnItem : StateMachineBehaviour
{
    private float delayTime = 1f;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        delayTime -= Time.deltaTime;
        if (delayTime <= 0f)
        {
            animator.GetComponent<Player>().Possess();
            animator.SetBool("isPossessed", false);

            delayTime = 1f;
        }
    }
}
