

public class EnemyDamageReceiver : DamageReceiver
{

    protected override void DestroyEnemy()
    {
        base.DestroyEnemy();
        ScoreManager.instance.Add(ScoreType.EnemyDeadCount.ToString(), 1);
        ScoreManager.instance.Add(ScoreType.GoldCount.ToString(), 1);
    }
}
