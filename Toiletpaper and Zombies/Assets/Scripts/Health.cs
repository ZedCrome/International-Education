using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth = 6;
    [SerializeField] protected float currentHealth;



    private void Start()
    {
        currentHealth = maxHealth;

    }

    public virtual void ChangeHealth(float amount)
    {
        currentHealth = currentHealth + amount;
        
        CheckHealth();
    }

    protected virtual void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Kill();
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Kill()
    {

    }

}
