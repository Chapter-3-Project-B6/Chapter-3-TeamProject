using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyContactController : EnemyController
{
    [SerializeField] private GameObject explosion;
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;

    CharacterStat currentStat;
    HealthSystem healthSystem;
    private int layermaskTarget;

    Vector2 dirTarget;

    protected override void Awake()
    {
        base.Awake();
        layermaskTarget = statHandler.currentStat.target;
        healthSystem = GetComponent<HealthSystem>();
    }

    protected override void OnEnable()
    {
        dirTarget = DirTarget();

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        float distanceTarget = DistanceTarget();

        CallMoveEvent(dirTarget);
        CallLookEvent(dirTarget);
        CheckNear(distanceTarget);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatched(statHandler.currentStat.target.value, collision.gameObject.layer))
        {
            GameManager.instance.Player1Score -= 10;
            GameObject obj = Instantiate(explosion);
            obj.transform.position = this.transform.position;
            gameObject.SetActive(false);
            Destroy(obj, 0.3f);
        }

        if (collision.tag == "Bullet")
        {
            OnDie();
        }
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    private void CheckNear(float distnace)
    {
        if (distnace <= shootRange)
        {
            ShootTarget(dirTarget);
        }
    }

    private void ShootTarget(Vector2 dir)
    {
        IsAttacking = true;
    }

    public void OnDie()
    {
        GameManager.instance.Player1Score += 100;
        GameObject obj = Instantiate(explosion);
        obj.transform.position = this.transform.position;
        gameObject.SetActive(false);
        DropItem();
        Destroy(obj, 0.3f);
    }

    private int randCount;
    private void DropItem()
    {
        randCount = Random.Range(0, 100);
        GameObject obj;

        if (randCount < 10)
        {
            obj = ObjectPool.Instance.SpawnFromPool("HealItem");
            obj.transform.position = transform.position;
        }
        else if (randCount < 20)
        {
            obj = ObjectPool.Instance.SpawnFromPool("Bomb");
            obj.transform.position = transform.position;
        }
    }
}
