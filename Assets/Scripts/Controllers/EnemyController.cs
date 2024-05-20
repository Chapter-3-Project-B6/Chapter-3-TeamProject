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
        closeTarget = gameManager.player;
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void FixedUpdate()
    {
        
    }


    protected float DistanceTarget()
    {
        return Vector3.Distance(transform.position, closeTarget.position);
    }

    public Vector2 DirTarget()
    {
        Debug.Log("CloseTarget" + closeTarget.position);
        Debug.Log("Enemy" + transform.position);
        return (closeTarget.position - transform.position).normalized;
    }
}
