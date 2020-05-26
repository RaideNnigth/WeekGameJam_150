using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviur : MonoBehaviour
{
    AI_Movement ai;
    
    void Update()
    {
        ai = FindObjectOfType<AI_Movement>();
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            ai.SpikesDamageEnter();
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            ai.SpikesDamageExit();
            Destroy(gameObject);
        }
    }
}
