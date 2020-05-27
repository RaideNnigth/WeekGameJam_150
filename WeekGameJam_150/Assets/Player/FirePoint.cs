using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bullet;
    public float shootDelay;
    public Animator animator;
    private bool canShoot = false;
   
    
    void Update()
    {
        animator.SetBool("attack", false);
        if (canShoot == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("attack", true);
                Instantiate(bullet, transform.position, transform.rotation);
                canShoot = true;
                StartCoroutine(wait());
            }
        }
    }

    IEnumerator wait() 
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = false;
    
    }
}
