using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToAPoint : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("missionComplete", false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float xPos = animator.GetComponent<NPC>().missionCompleteAreaXPosition;
        if (xPos > animator.GetComponent<Rigidbody2D>().transform.position.x)
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
        animator.GetComponent<NPC>().MoveToPositionWalking(new Vector3(xPos, animator.GetComponent<NPC>().transform.position.y, animator.GetComponent<NPC>().transform.position.z));

        if(animator.GetComponent<Rigidbody2D>().transform.position.x == xPos)
        {
            animator.SetBool("waitngForGameToEnd", true);
        }
    }
}
