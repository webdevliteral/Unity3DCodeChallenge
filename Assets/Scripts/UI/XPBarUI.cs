using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class XPBarUI : MonoBehaviour
{
    public Image xpSlider;
    public GameObject player;
    
    void Awake()
    {
        //subscribe to the onXPChange event of CharacterStats
        player.GetComponent<CharacterStats>().OnXPChanged += OnXPChanged;

    }
    void OnXPChanged(int xpNeeded, int currentXP)
    {
        Debug.Log("XP UI ONXPCHANGED");
        if(xpSlider != null)
        {
            float xpPercent = (float)currentXP / xpNeeded;
            xpSlider.fillAmount = xpPercent;
            if(xpSlider.fillAmount == 1)
            {
                xpSlider.fillAmount = 0;
            }
        }
    }
}
