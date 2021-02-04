using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private HUD hud;
    public EnemyData Data;
    private int m_enemyHealth;
    public void Start()
    {
        hud = HUD.instance;
        m_enemyHealth = Data.m_Health;
    }

    public void currentHP(int m_changeHealth)
    {
        m_enemyHealth -= m_changeHealth;
        hud.DamageDealt(m_changeHealth);

        if (m_enemyHealth == 0)
        {
            hud.KilledEnemies(1);
            gameObject.SetActive(false);
            //reset the current amount of health
            m_enemyHealth = Data.m_Health;
        }
    }
}
