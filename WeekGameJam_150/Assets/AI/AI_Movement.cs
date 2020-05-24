using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    [Header("Movement")]
    public float lookRadius;
    public float speed;
    public float stoppingDist;
    GameObject target;

    [Space]
    [Header("Shooting")]
    public GameObject bullet;
    public Transform FirePoint;
    public float TimeBtwnShots = 0.5f;
    private float lastShot;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("enemies");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= lookRadius)
        {
            if (distance >= stoppingDist)
            {
                transform.Translate((target.transform.position - transform.position) * speed * Time.deltaTime, Space.World);
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
    }

    private void FaceTarget()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, stoppingDist);
    }
}
