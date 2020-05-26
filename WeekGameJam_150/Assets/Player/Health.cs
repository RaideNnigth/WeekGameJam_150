using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int numOfHearths;
    public Image[] hearts;
    public Text counter;

    void Update() 
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            
            if (i < numOfHearths)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        counter.text = numOfHearths.ToString();

        if (numOfHearths == 0)
        {
            // respawn
        }


    }


    public void GetDamaged() 
    {
        numOfHearths--; 
    }
}