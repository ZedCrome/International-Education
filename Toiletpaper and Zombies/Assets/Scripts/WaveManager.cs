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
    public float m_waveTimer;

    private int m_waveCount;

    private void Start()
    {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {
        float m_currentWaitTimer = m_waveTimer;
        while (m_currentWaitTimer > 0)
        {
            yield return new WaitForSeconds(1f);
            m_currentWaitTimer--;
            
        }
        StartCoroutine(WaveSpawner());
    }

    IEnumerator WaveSpawner()
    {

        for (int i = 0; i < WaveLength * WaveMultiplier; i++)
        {
            yield return new WaitForSeconds(1f);
            GameObject m_currentSpawn = m_spawnLoc[Random.Range(0, m_spawnLoc.Length)];
            

            GameObject m_enemyType1 = ObjectPool.instance.SpawnPool("EnemyType1", m_currentSpawn.transform.position, Quaternion.identity);
            if (m_enemyType1 != null)
            {
                m_enemyType1.SetActive(true);
            }
        }
        WaveMultiplier++;
        m_waveCount++;
        StartCoroutine(CountDown());
    }
    

}
