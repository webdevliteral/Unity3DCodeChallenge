using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    //TODO: make into a list to add multiple quests
    public Quest quest;
    public GameObject player;

    public void IncreaseExperience(int expIncrease)
    {
        player.GetComponent<PlayerStats>().curExperience += expIncrease;
        player.GetComponent<PlayerStats>().GainExperience();
    }

    public void KillPlayer()
    {
        //reset scene when player dies
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
