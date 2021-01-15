using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public Stat rewardXP;
    public int xpReward;

    public override void Die()
    {
        base.Die();
        //add death effect

        //die
        if(PlayerManager.instance.quest != null)
        {
            if(PlayerManager.instance.quest.isActive)
            {
                PlayerManager.instance.quest.goal.EnemyKilled();
            }
        }
        PlayerManager.instance.IncreaseExperience(xpReward);
        Destroy(gameObject);
    }
}
