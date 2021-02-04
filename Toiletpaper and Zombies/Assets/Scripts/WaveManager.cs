using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("spawn locations")]
    public GameObject[] m_spawnLoc;

    [Header("Spawner Stats")]
    
    public int WaveLength;
    public int WaveMultiplier;
    public float m_cooldownTimer;
    public float m_timeBetweenSpawning = 1.7f;
    public string[] enemys;
    

    private void Start()
    {

        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {
        float m_currentWaitTimer = m_cooldownTimer;
        while (m_currentWaitTimer > 0)
        {
            Debug.Log("New Wave in " + m_currentWaitTimer);
            yield return new WaitForSeconds(1f);
            m_currentWaitTimer--;
            
        }
        
        StartCoroutine(WaveSpawner());
    }

    IEnumerator WaveSpawner()
    {
        
        Debug.Log("Starting New Wave");
        for (int i = 0; i < WaveLength * WaveMultiplier; i++)
        {
            yield return new WaitForSeconds(m_timeBetweenSpawning);
            GameObject m_currentSpawn = m_spawnLoc[Random.Range(0, m_spawnLoc.Length)];
            string abc = enemys[Random.Range(0, enemys.Length)];

            
            GameObject m_enemyType1 = ObjectPool.instance.SpawnPool("EnemyType" + abc, m_currentSpawn.transform.position, Quaternion.identity);
            
            if (m_enemyType1 != null)
            {
                m_enemyType1.SetActive(true);
            }
        }
        WaveMultiplier++;
        UIScript.instance.wavetext++;
        UIScript.instance.ChangeTextWave();
        



        StartCoroutine(WaveSpawner());
    }

}
