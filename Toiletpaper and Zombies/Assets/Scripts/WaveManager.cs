using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private HUD hud;
    
    [Header("spawn locations")]
    public GameObject[] m_spawnLoc;

    [Header("Spawner Stats")]
    
    public int WaveLength;
    public int WaveMultiplier;
    public float m_waveTimer;

    public int waveCount;

    private void Start()
    {
        hud = HUD.instance;
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
        Debug.Log("starting wave");
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
        waveCount++;
        hud.Wave(waveCount);
        StartCoroutine(CountDown());
    }
    

}
