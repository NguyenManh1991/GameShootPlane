

using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    public EnemyCtrl enemyCtrl;
    [SerializeField] protected float finalMaxHp = 0f;
    [SerializeField] protected string exExplosionName = "Explosion";
    [SerializeField] protected string exExplosionSoundName = "ExplosionSound";
    [SerializeField] protected List<Transform> explosionPoint;

    protected override void Start()
    {
        base.Start();
        enemyCtrl = GetComponentInParent<EnemyCtrl>();

    }

    protected virtual void FixedUpdate()
    {
        LoadExplosionPoint();
    }
    protected override void DestroyEnemy()
    {
        base.DestroyEnemy();
        ScoreManager.instance.Add(ScoreType.EnemyDeadCount.ToString());
        ScoreManager.instance.Add(ScoreType.GoldCount.ToString());
        SpawnExplosion();
    }
    protected virtual void SpawnExplosion()
    {
        if (explosionPoint.Count <= 0)
        {
            SpawnExplosionNonPoint();
            return;
        }
        SpawnExplosionByPoint();


    }

    protected virtual void SpawnExplosionByPoint()
    {
        foreach (Transform point in explosionPoint)
        {
            Vector3 pointExposion = transform.position;
            pointExposion = point.position;
            Transform exExplosion = FXManager.instance.Spawn(exExplosionName, pointExposion);
            exExplosion.gameObject.SetActive(true);
            Transform exExplosionSound = FXManager.instance.Spawn(exExplosionSoundName, pointExposion);
            exExplosionSound.gameObject.SetActive(true);
        }

    }

    protected virtual void SpawnExplosionNonPoint()
    {
        Transform exExplosion = FXManager.instance.Spawn(exExplosionName, transform.position);
        exExplosion.gameObject.SetActive(true);
        Transform exExplosionSound = FXManager.instance.Spawn(exExplosionSoundName, transform.position);
        exExplosionSound.gameObject.SetActive(true);
    }


    protected virtual void LoadExplosionPoint()
    {
        explosionPoint = enemyCtrl.model.ExplosionPoint();
    }

    public override float MaxHp()
    {
        float maxHp = base.MaxHp();
        int gameLevel = GameLevel.Instance.CurrentLevel();
        finalMaxHp = maxHp + gameLevel;
        return finalMaxHp;
    }
}
