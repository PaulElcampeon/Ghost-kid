using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Death : StateMachineBehaviour
{
    private float delay;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        delay-= Time.deltaTime;
        if(delay <= 0)
        {
            GameManager.instance.isDead = true;
        }
    }
}
