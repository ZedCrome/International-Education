using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class objpool
    {
        public GameObject prefab;
        public string tag;
        public int poolSize;

    }
    public static ObjectPool instance;
    public Dictionary<string, Queue<GameObject>> poolDic;
    public List<objpool> pools;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    void Start()
    {
        poolDic = new Dictionary<string, Queue<GameObject>>();

        foreach (objpool pool in pools)
        {
            Queue<GameObject> objectQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectQueue.Enqueue(obj);
            }

            poolDic.Add(pool.tag, objectQueue);
        }

    }

    public GameObject SpawnPool(string tag, Vector3 pos, Quaternion rot)
    {
        if (!poolDic.ContainsKey(tag))
        {
            Debug.Log("TAG IS NOT GIVEN" + tag);

            return null;
        }
        GameObject ObjectToSpawn = poolDic[tag].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = pos;
        ObjectToSpawn.transform.rotation = rot;

        poolDic[tag].Enqueue(ObjectToSpawn);
        iPooled pooled = ObjectToSpawn.GetComponent<iPooled>();
        if (pooled != null)
        {
            pooled.OnSpawn();
        }
        return ObjectToSpawn;
    }

}
