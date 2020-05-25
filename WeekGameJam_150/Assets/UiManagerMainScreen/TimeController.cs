using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TimeController : MonoBehaviour
{
    public Text timer;
    public SpawnHero spawnHero;
    public CubePlacer cubePlacer;
    private float currentTime = 0f;
    private float startingTime;

    
    void Start()
    {
        startingTime = Random.Range(59, 90);
        currentTime = startingTime;
    }

    void Update()
    {

        
        currentTime -= 1 * Time.deltaTime;
        float seconds = currentTime;
        timer.text = seconds.ToString("0");
        
        if (timer.text == "0")
        {
            cubePlacer.Stop();
            spawnHero.Spawn();
            Destroy(timer.gameObject);
        }
    }
}
