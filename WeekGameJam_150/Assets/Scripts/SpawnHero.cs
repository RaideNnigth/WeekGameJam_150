using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class SpawnHero : MonoBehaviour
{
    public GameObject hero;
    public int minX;
    public int maxX;
    public int minZ;
    public int maxZ;
    public int SceneIndexPassLevel;
    private bool canSpawn = true;
    private int spawnCounter = 0;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if(spawnCounter > 3)
        {
            SceneManager.LoadScene(SceneIndexPassLevel);
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
       
        if (canSpawn == true)
        {
            Instantiate(hero, new Vector3(x, transform.position.y, z), transform.rotation);
            canSpawn = false;
            spawnCounter += 1;

            //Play respawn voiceovers
            StartCoroutine(PlayVoiceOvers());
        }

        StartCoroutine(wait());
    }

    IEnumerator PlayVoiceOvers()
    {
        if (spawnCounter == 2)
        {
            audioManager.Find("Main Menu Song").source.volume = 0.4f;
            audioManager.Play("Second Life");
            yield return new WaitForSeconds(2f);
            audioManager.Find("Main Menu Song").source.volume = 1f;
        }
        else if (spawnCounter == 3)
        {
            audioManager.Find("Main Menu Song").source.volume = 0.4f;
            audioManager.Play("Multiple Lives");
            yield return new WaitForSeconds(3.5f);
            audioManager.Find("Main Menu Song").source.volume = 1f;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        canSpawn = true;
    }
}
