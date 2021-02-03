using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth = 10;
    [SerializeField] protected float currentHealth;

    public HUD hud;

    private void Start()
    {
        currentHealth = maxHealth;
        hud = HUD.instance;
    }

    public virtual void ChangeHealth(float amount)
    {
        currentHealth = currentHealth + amount;
        hud.Hp(amount, maxHealth);
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
