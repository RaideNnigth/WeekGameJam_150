using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    AI_Movement movement;
    private void Start()
    {
        movement = GetComponent<AI_Movement>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(movement.isRunning == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
