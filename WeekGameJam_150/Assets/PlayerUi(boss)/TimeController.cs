using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TimeController : MonoBehaviour
{
    public Text timer;
    private float currentTime = 0f;
    private float startingTime;
    
    void Start()
    {
        startingTime = Random.Range(119, 181);
        currentTime = startingTime;
    }

    void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        float minutes = currentTime / 60;
        float seconds = currentTime % 60;

        timer.text = (minutes - 1).ToString("0") + ":" + seconds.ToString("0");

    }
}
