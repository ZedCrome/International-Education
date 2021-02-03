using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject EnemyPref;
    public int WaveLength;
    public int WaveMultiplier;

    private void Start()
    {
        if (WaveLength == 0)
            WaveLength = 1;
        StartCoroutine(EnemyWaveSpawner());
    }
    IEnumerator EnemyWaveSpawner()
    {
        for (int i = 0; i < WaveLength * WaveMultiplier; i++)
        {
            Instantiate(EnemyPref, Vector3.zero, Quaternion.identity);
        }
        WaveMultiplier++;
        yield return new WaitForSeconds(1f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(EnemyWaveSpawner());
    }
}
