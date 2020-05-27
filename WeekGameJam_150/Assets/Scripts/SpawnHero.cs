using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnHero : MonoBehaviour
{
    public GameObject hero;
    public int minX;
    public int maxX;
    public int minZ;
    public int maxZ;
    private bool canSpawn = true;
    private int spawnCounter = 0;

    void Update()
    {
        if(spawnCounter > 3)
        {
            //Here you implement the trasition to the next level
        }
    }
    public void Spawn ()
    {
        Instantiate(hero, transform.position, transform.rotation);
        spawnCounter += 1;
    }
    
    public void RandomSpawn()
    {
        int x = Random.Range(minX, maxX);
        int z = Random.Range(minZ, maxZ);
        if (canSpawn == false)
        {
            canSpawn = true;
        }
        if (canSpawn == true)
        {
            Instantiate(hero, new Vector3(x, transform.position.y, z), transform.rotation);
            canSpawn = false;
            spawnCounter += 1;
        }
    }

}
