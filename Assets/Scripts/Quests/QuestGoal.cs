using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType questGoal;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        //if this is true, return true. if not, return false
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if(questGoal == GoalType.Kill)
        {
            currentAmount++;
        }
        
    }

    public void ItemCollected()
    {
        if(questGoal == GoalType.Collect)
        {
            currentAmount++;
        }
        
    }
}

public enum GoalType {Kill, Collect, Locate, TalkTo}
