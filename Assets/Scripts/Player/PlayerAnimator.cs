using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Possess()
    {
        animator.SetTrigger("Possess");
    }

    public void Unpossess()
    {
        animator.SetTrigger("Unpossess");
    }

    public void Death()
    {
        animator.SetTrigger("Dead");
    }

    public void Idle()
    {
        animator.SetTrigger("Idle");
    }
}
