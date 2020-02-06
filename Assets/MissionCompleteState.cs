using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCompleteState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NPC>().heartParticles.SetActive(true);
    }
}
