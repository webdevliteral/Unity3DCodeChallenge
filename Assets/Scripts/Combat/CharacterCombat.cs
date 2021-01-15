using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = .6f;
    public bool inCombat{get; private set;}
    const float combatCooldown = 25f;
    float lastAttackTime;

    //simple delegate with return of void to make animating easier
    public event System.Action OnAttack;
    CharacterStats myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if(Time.time - lastAttackTime > combatCooldown)
        {
            inCombat = false;
            //if out of combat, restore health
            if(myStats.currentHealth < myStats.maxHealth)
            {
                Debug.Log("Replenishing health out of combat!");
                myStats.SlowReplenishHealth();
            }
        }
    }
    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            if(OnAttack != null)
            {
                OnAttack();
            }
            attackCooldown = 1f / attackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }

        TooltipSystem.HideTooltip();
        
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
        if(stats.currentHealth <= 0)
        {
            inCombat = false;
        }
    }
}
