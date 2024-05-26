

using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    [SerializeField] protected string exExplosionName = "Explosion";

    protected override void DestroyEnemy()
    {
        base.DestroyEnemy();
        ScoreManager.instance.Add(ScoreType.EnemyDeadCount.ToString(), 1);
        ScoreManager.instance.Add(ScoreType.GoldCount.ToString(), 1);
        SpawnExplosion();
    }
    protected virtual void SpawnExplosion()
    {
      Transform exExplosion =  FXManager.instance.Spawn(exExplosionName, transform.position);
        exExplosion.gameObject.SetActive(true);
    }
}
