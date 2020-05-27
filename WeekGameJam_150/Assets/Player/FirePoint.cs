using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bullet;
    public float shootDelay;
    public Animator animator;
    private bool canShoot = false;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        animator.SetBool("attack", false);
        if (canShoot == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Shoot
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        animator.SetBool("attack", true);

        //Wait for animations to show that the boss is shooting
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, transform.position, transform.rotation);

        //Play Boss Shooting Sound
        audioManager.Play("Boss Shooting");

        canShoot = true;
        yield return new WaitForSeconds(shootDelay);
        canShoot = false;
    }
}
