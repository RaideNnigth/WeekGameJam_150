using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapBehaviur : MonoBehaviour
{
    AI_Movement ai;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("is", false);
    }
    void Update()
    {
        ai = FindObjectOfType<AI_Movement>();
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("is", true);
            ai.BearTrapDamageEnter();
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("is", false);
            ai.BearTrapDamageExit();
            Destroy(gameObject);
        }
        
    }
}
