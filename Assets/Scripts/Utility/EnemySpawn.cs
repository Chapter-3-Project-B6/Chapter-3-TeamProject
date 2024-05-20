using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    EnemyController enemyController;

    public string nameTag;

    public Vector2 spawnAreaSize = new Vector2(20f, 10f);

    private float spawnTime = 1f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(nameTag));
    }

    private IEnumerator SpawnEnemy(string nameTag)
    {
        while (true)
        {
            GameObject obj = SpawnManager.instance.EnemyObjectPool.GetEnemy(nameTag, false);

            Vector2 spawnPosition = GetSpawnPosition();
            obj.transform.position = spawnPosition;
            obj.SetActive(true);

            yield return new WaitForSeconds(spawnTime);
        }
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        spawnPosition = new Vector3(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f), Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f), 0f);
        if (Mathf.Abs(spawnPosition.x) < spawnAreaSize.x / 2f)
        {
            if (spawnPosition.x > 0f)
            {
                spawnPosition.x += 10f;
            }

            else
            {
                spawnPosition.x -= 10f;
            }
        }
        return spawnPosition;
    }
}
