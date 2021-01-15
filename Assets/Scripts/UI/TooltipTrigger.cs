using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string content;
    public string header;
    public void OnPointerEnter(PointerEventData data)
    {
        Debug.Log(this.name);
        TooltipSystem.ShowTooltip(content, header);
    }

    public void OnPointerExit(PointerEventData data)
    {
        TooltipSystem.HideTooltip();
    }
}
