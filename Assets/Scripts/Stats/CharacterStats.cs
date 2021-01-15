using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    //any class can get this value, but it can only be set from within local scope
    public int currentHealth{get; private set;}
    public Stat damage;
    public Stat armor;
    public int curExperience;
    public int reqExperience;
    public int level;
    public int currency;

    public event System.Action<int, int> OnHealthChanged;
    public event System.Action<int, int> OnXPChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void SlowReplenishHealth()
    {
        currentHealth++;
    }

    public void TakeDamage(int damage)
    {
        //modify the damage based on stats
        damage -= armor.GetValue(); //armor.GetValue calls GetValue() from the stat class
        //make sure damage doesn't dampen below 0
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " took " + damage + " damage!");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void GainExperience()
    {
        if (OnXPChanged != null)
        {
            OnXPChanged(reqExperience, curExperience);
        }
    }

    public virtual void Die()
    {
        //make character die
        //override for custom use cases
        Debug.Log(transform.name + " has died.");
    }
}
