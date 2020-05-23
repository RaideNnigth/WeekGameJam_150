using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;
    public float shootDelay;
    private bool canShoot = false;
    
    void Update()
    {
        if (canShoot == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, firepoint.position, firepoint.rotation);
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
