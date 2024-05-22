using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyRangeController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;
    [SerializeField] private GameObject explosion;

    CharacterStat currentStat;
    HealthSystem healthSystem;
    private int layermaskTarget;

    Vector2 dirTarget;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        layermaskTarget = statHandler.currentStat.target;
        healthSystem = GetComponent<HealthSystem>();
    }

    protected override void OnEnable()
    {
        dirTarget = DirTarget();
        healthSystem.ChangeHealth(statHandler.currentStat.health = 5);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        float distanceTarget = DistanceTarget();

        CallMoveEvent(dirTarget);
        CallLookEvent(dirTarget);
        EnemyState(distanceTarget);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (IsLayerMatched(statHandler.currentStat.target.value, collision.gameObject.layer))
        {
            GameManager.instance.Player1Score += 500;
            GameObject obj = Instantiate(explosion);
            obj.transform.position = this.transform.position;
            gameObject.SetActive(false);
            Destroy(obj, 0.3f);
            AudioManager.instance.PlaySFX("EnemyDestroySFX");
        }

        if (collision.tag == "Bullet")
        {
            GameManager.instance.Player1Score += 500;
            GameObject obj = Instantiate(explosion);
            obj.transform.position = this.transform.position;
            gameObject.SetActive(false);
            Destroy(obj, 0.3f);
            AudioManager.instance.PlaySFX("EnemyDestroySFX");
        }
    }

    private void EnemyState(float distanceTarget)
    {
        IsAttacking = false;
        CheckNear(distanceTarget);
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


    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
