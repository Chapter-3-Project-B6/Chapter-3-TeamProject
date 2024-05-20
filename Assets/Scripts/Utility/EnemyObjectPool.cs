using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyObjectPool : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public string tag;
        public GameObject enemyPrefab;
        public int poolsize = 10;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.poolsize; i++)
            {
                GameObject enemy = Instantiate(pool.enemyPrefab);
                enemy.SetActive(false);
                queue.Enqueue(enemy);
            }
            poolDictionary.Add(pool.tag, queue);
        }

    }
    
    public GameObject GetEnemy(string tag, bool isActive)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        obj.SetActive(isActive);
        return obj;
    }
}
