using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public bool hasQuest;
    //public Quest quest;
    public Dialogue dialogue;
    public GameObject playerTarget;
    public string npcName;

    void Start()
    {
        if(interactPosition == null)
        {
            interactPosition.position = transform.position;
        }
    }

    public override void Interact()
    {
        base.Interact();
        //trigger dialogue, do something, etc
        TriggerDialogue();
        /* if(quest != null)
        {
            QuestManager.instance.quest = quest;
            QuestManager.instance.OpenQuestWindow();
        } */

    }

    public void TriggerDialogue()
    {
        Debug.Log("Dialogue is connected!");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnMouseOver()
    {
        //TooltipSystem.ShowTooltip("", npcName);
    }

    public void OnMouseExit()
    {
        //TooltipSystem.HideTooltip();
    }
    
}
