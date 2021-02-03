using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int m_enemyHealth = 10;
    
    public void currentHP(int m_changeHealth)
    {
        m_enemyHealth -= m_changeHealth;

        Debug.Log(m_enemyHealth);
        if (m_enemyHealth == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
