using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image ImgHealthBar;
    public float mCurrentValue;
    public float min;
    public float max;
    private float mCurrentPercent;
    private float Health = 100;
    
    // Start is called before the first frame update
    void Update()
    {
        SetHealth(Health);
    }

    public void SetHealth(float health)
    {
        if (health != mCurrentValue)
        {
            
            if (max - min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
                
            else 
            {
                mCurrentValue = health;
                mCurrentPercent = mCurrentValue / (max - min);
            }
            ImgHealthBar.fillAmount = mCurrentPercent;
        }
    }

    public void GetHit(float health) 
    {
        Health = health;    
    }
}
