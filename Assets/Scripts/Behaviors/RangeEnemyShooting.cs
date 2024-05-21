using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyShooting : MonoBehaviour
{
    private DodgeController _controller;
    private EnemyController _enemyController;
    private Vector2 _aimDirection = Vector2.up;

    private int numberOfProjectiles = 8;
    private float spreadAngle = 360f;

    private void Awake()
    {
        _controller = GetComponent<DodgeController>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        _controller.OnAttackEvent += OnShoot;
    }

    private void OnShoot(CharacterStat currentStat)
    {
        for(int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = spreadAngle * i / numberOfProjectiles;
            Vector2 direction = RotateVector2(transform.right, angle);

            GameObject obj = SpawnManager.instance.ObjectPool.SpawnFromPool(currentStat.nameTag);
            ProjectileController attackController = obj.GetComponent<ProjectileController>();

            obj.transform.position = transform.position;
            attackController.InitializeAttack(direction, currentStat);
        }
    }

    private static Vector2 RotateVector2(Vector2 vector, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(radian);
        float sin = Mathf.Sin(radian);
        float x = vector.x * cos - vector.y * sin;
        float y = vector.x * sin + vector.y * cos;
        return new Vector2(x, y);
    }
}
