using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject LivesPanel;
    public GameObject MinionsPanel;
    public GameObject PlayerHealthBar;
    public GameObject Timer;
    public GameObject MovementTutorial;
    public GameObject PressSpace;

    public FirePoint shooting;
    public ThirdPersonCharacterController characterController;

    private int currentTutorial = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentTutorial++;
            NextTutorial(currentTutorial);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Change scene here
            //SceneManager.LoadScene();
        }
    }

    private void NextTutorial(int _currentTutorial)
    {
        switch (_currentTutorial)
        {
            case 0:
                LivesPanel.SetActive(true);
                break;
            case 1:
                LivesPanel.SetActive(false);
                MinionsPanel.SetActive(true);
                break;
            case 2:
                MinionsPanel.SetActive(false);
                PlayerHealthBar.SetActive(true);
                break;
            case 3:
                PlayerHealthBar.SetActive(false);
                Timer.SetActive(true);
                break;
            case 4:
                Timer.SetActive(false);
                MovementTutorial.SetActive(true);
                characterController.enabled = true;
                break;
            case 5:
                MovementTutorial.SetActive(false);
                PressSpace.SetActive(true);
                break;
            case 6:
                shooting.enabled = true;
                break;
            default:
                break;
        }
    }
}
