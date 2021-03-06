﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Movement_Minions : MonoBehaviour
{
    [Header("Movement")]
    public float lookRadius;
    public float speed;
    public float stoppingDist;
    public string targetsTag;
    [HideInInspector] public bool isRunning;
    GameObject target;

    [Space]
    [Header("Shooting")]
    public GameObject bullet;
    public Transform FirePoint;
    public float TimeBtwnShots = 0.5f;
    private float lastShot;

    public float Health = 2;

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag(targetsTag);
        
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
            isRunning = false;
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
        if (collision.tag == "Hero_Bullet")
        {
            
            if (Health > 0)
            {
                Health -= 1;
            }
            else
            {
               
                Destroy(gameObject);
            }
           
            
        }
    }
    // if we want to see the wireSphere again
    //private void OnDrawGizmos()
    //{
    //   Gizmos.DrawWireSphere(transform.position, lookRadius);
    //  Gizmos.DrawWireSphere(transform.position, stoppingDist);
    //}
}
