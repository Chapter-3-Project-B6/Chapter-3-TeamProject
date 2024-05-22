using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_Type
{
    IT_Power,
    IT_Boom,
    IT_Heart
}

public class Item : MonoBehaviour
{
    [SerializeField]
    private Item_Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            switch (type)
            {
                case Item_Type.IT_Heart:
                    AudioManager.instance.PlaySFX("HeartItemSFX");
                    if (collision.TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
                    {
                        healthSystem.ChangeHealth(3);
                    }
                    gameObject.SetActive(false);
                    break;
                case Item_Type.IT_Boom:
                    Explosion();
                    gameObject.SetActive(false);
                    break;
            }
        }
    }

    public void Explosion()
    {
        AudioManager.instance.PlaySFX("BoomItemSFX");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] rangeEnemys = GameObject.FindGameObjectsWithTag("RangeEnemy");
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i].TryGetComponent<EnemyContactController>(out EnemyContactController enemy))
                enemy.OnDie();
        }

        for (int i = 0; i < rangeEnemys.Length; i++)
        {
            if (rangeEnemys[i].TryGetComponent<EnemyRangeController>(out EnemyRangeController rangeEnemy))
                rangeEnemy.OnDie();
        }

            for (int i = 0; i < enemyBullets.Length; i++)
        {
            enemyBullets[i].SetActive(false);
        }
    }
}