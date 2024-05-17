
using System.Collections.Generic;
using UnityEngine;


public class EnemyMoveByPath :MoveByPath 
{
    [Header("Enemy")]
    public EnemyCtrl enemyCtrl;

    protected override void Start()
    {
        base.Start();
        
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected override void Moving()
    {
        base.Moving();
        if(IsTheEndOfPath()) { enemyCtrl.deSpawn.DeSpawning(); }
    }
}
