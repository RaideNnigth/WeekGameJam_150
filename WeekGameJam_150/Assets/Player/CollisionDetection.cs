using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public Health health;

    public void OnTriggerEnter(Collider colision)
    {
        if (colision.gameObject.tag == "enemies")
        {
            health.GetDamaged();
        }
    }
}
