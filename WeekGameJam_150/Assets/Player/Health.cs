using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int numOfHearths;
    public Image[] hearts;

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
    }


    public void GetDamaged() 
    {
        numOfHearths--; 
    }
}