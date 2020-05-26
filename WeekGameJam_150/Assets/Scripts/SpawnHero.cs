using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHero : MonoBehaviour
{
    public GameObject hero;
    public void Spawn ()
    {
        Instantiate(hero, transform.position, transform.rotation);
    }
}
