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
    

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag(targetsTag);
        waitTime = startWaitTime;
        moveSpot = GameObject.Find("MoveSpot").GetComponent<Transform>();
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
        healthBar = FindObjectOfType<HealthBar>();

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
            }
            else
            {
                //If this Gameobject has reached near the target then dont run.
                isRunning = false;
            }

            //Face Target
            FaceTarget();

            //Shoot
            float startTime = Time.time;
            if (Time.time > TimeBtwnShots + lastShot)
            {
                Instantiate(bullet, FirePoint.transform.position, transform.rotation);
                lastShot = Time.time;
            }
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

            if(Vector3.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if(waitTime <= 0)
                {
                    moveSpot.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                    waitTime = startWaitTime;
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
        speed = speed/10;
        bulletDamage = 2;
    }

    public void BearTrapDamageExit()
    {
        speed = speed * 10;
        bulletDamage = 1;
    }
    // if we want to see the wireSphere again
    //private void OnDrawGizmos()
    //{
    //   Gizmos.DrawWireSphere(transform.position, lookRadius);
    //  Gizmos.DrawWireSphere(transform.position, stoppingDist);
    //}
}
