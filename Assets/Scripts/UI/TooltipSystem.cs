﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem instance;
    public Tooltip tooltip;
    public void Awake()
    {
        instance = this;
    }

    public static void ShowTooltip(string content, string header = "")
    {
        instance.tooltip.SetText(content, header);
        instance.tooltip.gameObject.SetActive(true);
    }

    public static void HideTooltip()
    {
        instance.tooltip.gameObject.SetActive(false);
    }
}
