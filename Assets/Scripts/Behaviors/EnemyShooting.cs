using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private DodgeController _controller;
    private EnemyController _enemyController;
    private Vector2 _aimDirection = Vector2.up;

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
        GameObject obj = ObjectPool.Instance.SpawnFromPool(currentStat.nameTag);

        obj.transform.position = transform.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(_enemyController.DirTarget(), 0f), currentStat);
    }

    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * v;
    }
}
