using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Storymanager : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine(StartStory());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.Find("Story_VoiceLines").source.Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    IEnumerator StartStory()
    {
        //Set Audio
        audioManager.Find("Main Menu Song").source.volume = 0.3f;
        audioManager.Play("Story_VoiceLines");

        text1.SetActive(true);

        yield return new WaitForSeconds(5);
        text1.SetActive(false);
        text2.SetActive(true);

        yield return new WaitForSeconds(6);
        text2.SetActive(false);
        text3.SetActive(true);

        yield return new WaitForSeconds(8);
        text3.SetActive(false);
        text4.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        text4.SetActive(false);
        text5.SetActive(true);

        yield return new WaitForSeconds(6);
        text5.SetActive(false);
        text6.SetActive(true);

        yield return new WaitForSeconds(4);

        audioManager.Find("Main Menu Song").source.volume = 1f;
        audioManager.Find("Story_VoiceLines").source.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}
