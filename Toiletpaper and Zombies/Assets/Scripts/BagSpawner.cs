using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSpawner : MonoBehaviour
{
    private void Start()
    {
        Invoke("Spawnin", 1f);
    }


    private void Spawning()
    {
        ObjectPool.instance.SpawnPool("ScoreBag", Vector3.zero, Quaternion.identity);
    }

}
