using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storymanager : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    float timer;

    void Start()
    {
        text1.SetActive(true);
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5 && timer < 10){
            text1.SetActive(false);
            text2.SetActive(true);
        } else if (timer >= 10 && timer < 15)
        {
            text2.SetActive(false);
            text3.SetActive(true);
        }
        else if (timer >= 15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
