using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeController : MonoBehaviour
{
    public Text timer;
    public SpawnHero spawnHero;
    public CubePlacer cubePlacer;
    private float currentTime = 0f;
    private float startingTime = 15;
    private bool timeZero = false;

    
    void Start()
    {
        cubePlacer = FindObjectOfType<CubePlacer>();
        currentTime = startingTime;
    }

    void Update()
    {

        
        currentTime -= 1 * Time.deltaTime;
        float seconds = currentTime;
        
        if (timer.text == "0" )
        {

            cubePlacer.Stop();
            spawnHero.Spawn();
            timeZero = true;
            Destroy(this);
            
        }
        if (timer.text != "0" && timeZero == false)
        {
            timer.text = seconds.ToString("0");
        }
    }
}

