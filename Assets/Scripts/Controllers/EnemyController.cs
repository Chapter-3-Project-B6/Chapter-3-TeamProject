using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class EnemyController : DodgeController
{
    protected Transform closeTarget { get; private set; }
    GameManager gameManager;

    protected override void Awake()
    {
        base.Awake();
        gameManager = GameManager.instance;
        closeTarget = gameManager.Player;
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void FixedUpdate()
    {
        
    }


    protected float DistanceTarget()
    {
        if(closeTarget != null)
        {
            return Vector3.Distance(transform.position, closeTarget.position);
        }

        else
        {
            return 0f;
        }
    }

    public Vector2 DirTarget()
    {
        if(closeTarget != null)
        {
            return (closeTarget.position - transform.position).normalized;

        }

        else
        {
            return Vector2.zero;
        }
    }
}
