using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;
    public string enemyName;
    public string enemyDescription;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
    public override void Interact()
    {
        base.Interact();
        //attack enemy
            //find combat script to determine combat logic
        CharacterCombat combat = playerManager.player.GetComponent<CharacterCombat>();
        if(combat != null)
        {
            //Attack the enemy
            combat.Attack(myStats);
        }
    }

    public void OnMouseOver()
    {
        TooltipSystem.ShowTooltip(enemyDescription, enemyName);
    }

    public void OnMouseExit()
    {
        TooltipSystem.HideTooltip();
    }
}
