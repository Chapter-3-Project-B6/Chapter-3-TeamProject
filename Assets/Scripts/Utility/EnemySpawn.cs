using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    EnemyController enemyController;

    public string enemyTag;
    public string rangeEnemyTag;


    public Vector2 spawnAreaSize = new Vector2(20f, 10f);

    private float spawnTime = 1f;
    private int score;
    private bool isRangeEnemySpawn = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        score = GameManager.instance.Player1Score;

        if(score > 1000 && !isRangeEnemySpawn)
        {
            StartCoroutine(SpawnRangeEnemy());
            isRangeEnemySpawn = true;
        }
    }

    private IEnumerator SpawnEnemy()
    {

        while (true)
        {
            GameObject enemy = SpawnManager.instance.EnemyObjectPool.GetEnemy(enemyTag, false);

            Vector2 spawnPosition = GetSpawnPosition();
            enemy.transform.position = spawnPosition;
            enemy.SetActive(true);

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private IEnumerator SpawnRangeEnemy()
    {
        while (true)
        {
            GameObject rangeEnemy = SpawnManager.instance.EnemyObjectPool.GetEnemy(rangeEnemyTag, false);

            Vector2 spawnPosition = GetSpawnPosition();
            rangeEnemy.transform.position = spawnPosition;
            rangeEnemy.SetActive(true);

            yield return new WaitForSeconds(spawnTime + 1f);
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
