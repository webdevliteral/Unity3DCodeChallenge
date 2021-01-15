using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text rewardText;
    public Quest quest;
    public static QuestManager instance;

    void Awake()
    {
        instance = this;
        questWindow.SetActive(false);
    }

    void Update()
    {
        
        //check if quest is complete
        if(PlayerManager.instance.quest != null)
        {
            if(PlayerManager.instance.quest.isActive)
            {
                if(PlayerManager.instance.quest.goal.IsReached())
                {
                    PlayerManager.instance.IncreaseExperience(quest.experienceReward);
                    quest.Complete();
                }
            }
        }
    }

    void LateUpdate()
    {
        //check if the player has moved away
        if(PlayerController.instance.focusTarget != null)
        {
            float distance = Vector3.Distance(PlayerManager.instance.player.transform.position, PlayerController.instance.focusTarget.transform.position);
            //cancel dialogue if moved too far
            if(distance > PlayerController.instance.focusTarget.GetComponent<NPC>().radius + PlayerController.instance.focusTarget.GetComponent<NPC>().radiusPadding)
            {
                CloseQuestWindow();
            }
        }
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        rewardText.text = quest.experienceReward.ToString();
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        //give quest to player
        PlayerManager.instance.quest = quest;
    }
}
