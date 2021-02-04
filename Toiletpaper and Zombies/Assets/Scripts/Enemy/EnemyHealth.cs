using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public EnemyData Data;
    private int m_enemyHealth;
    public void Start()
    {
        m_enemyHealth = Data.m_Health;
    }

    public void currentHP(int m_changeHealth)
    {
        m_enemyHealth -= m_changeHealth;
       
        

        if (m_enemyHealth <= 0)
        {
            
            //reset the current amount of health
            m_enemyHealth = Data.m_Health;
            gameObject.SetActive(false);
            
           
        }
    }
}
