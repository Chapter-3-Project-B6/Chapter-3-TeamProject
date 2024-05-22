using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;

    public static ObjectPool Instance
    {
        get => instance;
    }

    [Serializable]
    public class Pool
    {
        public GameObject prefab;
        public string tag;
        public int poolSize;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);

        return obj;
    }

    public GameObject GetEnemy(string tag, bool isActive)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        obj.SetActive(isActive);
        return obj;
    }
}
