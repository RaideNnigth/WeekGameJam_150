using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using Random = UnityEngine.Random;

public class AI_Movement : MonoBehaviour
{
    [Header("Movement")]
    public float lookRadius;
    public float speed;
    public float stoppingDist;
    public string targetsTag;
    public Transform moveSpot;
    private AudioManager audioManager;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    
    [HideInInspector] public bool isRunning;
    GameObject target;
    

    [Space]
    [Header("Shooting")]
    public GameObject bullet;
    public Transform FirePoint;
    public float TimeBtwnShots = 0.5f;
    private float lastShot;
    private float bulletDamage = 1;

    public float Health = 100;
    public HealthBar healthBar;

    private float waitTime;
    public float startWaitTime;
    public Animator animator;
    SpawnHero spawnHero;


    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag(targetsTag);

        spawnHero = FindObjectOfType<SpawnHero>();
        waitTime = startWaitTime;
        moveSpot = GameObject.Find("MoveSpot").GetComponent<Transform>();
        audioManager = FindObjectOfType<AudioManager>();
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
        healthBar = FindObjectOfType<HealthBar>();
        animator.SetBool("running", false);
        animator.SetBool("attack", false);

    }

    void Update()
    {
        if (target == null)
        {
            //Debug.Log("No target Available");
            target = GameObject.FindGameObjectWithTag(targetsTag);
            return;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= lookRadius)
        {
            if (distance >= stoppingDist)
            {
                isRunning = true;
                Vector3 newPos = target.transform.position - transform.position;
                transform.Translate(newPos * speed * Time.deltaTime, Space.World);
                animator.SetBool("running", true);
            }
            else
            {
                //If this Gameobject has reached near the target then dont run.
                isRunning = false;
                animator.SetBool("running", false);
            }

            //Face Target
            FaceTarget();

            //Shoot
            float startTime = Time.time;
            if (Time.time > TimeBtwnShots + lastShot)
            {
                Instantiate(bullet, FirePoint.transform.position, transform.rotation);

                //Play Bullet Shot Sound
                audioManager.Play("Hero Shooting");

                lastShot = Time.time;
                animator.SetBool("attack", true);
            }
            else 
            {
                animator.SetBool("attack", false);
            }
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, 8 * Time.deltaTime);
            animator.SetBool("running", true);
            if (Vector3.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if(waitTime <= 0)
                {
                    moveSpot.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                    waitTime = startWaitTime;
                    animator.SetBool("running", false);
                }

                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        
    }
    private void FaceTarget()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.tag == "enemies" || collision.tag == "Player_Bullets")
        {
            if (Health > 0)
            {
                Health -= bulletDamage;
                healthBar.GetHit(Health);
            }

            else 
            {
                spawnHero.RandomSpawn();
                Destroy(gameObject);
            }
        }
    }

    public void SpikesDamageEnter()
    { 
        speed = speed / 3.5f;
        Health -= 10;
        healthBar.GetHit(Health);
    }

    public void SpikesDamageExit()
    {
        speed = speed * 3.5f;
    }

    public void BearTrapDamageEnter()
    {
        speed = speed/3.5f;
        bulletDamage = 2;
    }

    public void BearTrapDamageExit()
    {
        speed = speed * 3.5f;
        bulletDamage = 1;
    }
    // if we want to see the wireSphere again
    //private void OnDrawGizmos()
    //{
    //   Gizmos.DrawWireSphere(transform.position, lookRadius);
    //  Gizmos.DrawWireSphere(transform.position, stoppingDist);
    //}
}
