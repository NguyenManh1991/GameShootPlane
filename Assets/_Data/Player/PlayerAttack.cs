using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    public float attackDelay = 0.5f;
    public float fixedTimer = 0f;
    public float baseDelay = 1f;
    public float finalDelay = 1f;
    public float minDelay = 0.05f;
    public float speedDelay = 0.05f;
    string BulletPlayer = "BulletPlayer";
    [SerializeField] protected List<Transform> strikePoint;


    protected virtual void Start()
    {
        //playerCtrl = GetComponentInParent<PlayerCtrl>();
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();

    }
    protected virtual void FixedUpdate()
    {
        FixedAttacking();

    }
    protected virtual void FixedAttacking()
    {
        if (GameOver.Instance.IsGameOver()) return;
        fixedTimer += Time.fixedDeltaTime;
        if (fixedTimer < Delay()) return;
        fixedTimer = 0f;
        LoadStrikepoint();
        PlayerAttacking();
    }

    protected virtual float Delay()
    {
        int level = playerCtrl.playerLevel.CurrentLevel();
        finalDelay = baseDelay - (level * speedDelay);
        if (finalDelay < minDelay) finalDelay = minDelay;
        return finalDelay;
    }

    protected virtual void PlayerAttacking()
    {
        if (strikePoint.Count <= 0)
        {
            AttackWithNoStrikePoint();
            return;
        }

        AttackWithStrikePoint();

    }
    protected virtual void AttackWithNoStrikePoint()
    {
        Vector3 shootPosition = transform.position;
        SpawnBullet(shootPosition);
    }
    protected virtual void AttackWithStrikePoint()
    {
        foreach (var strikePoint in strikePoint)
        {
            Vector3 shootPosition = strikePoint.position;
            Quaternion rotation = strikePoint.rotation;

            SpawnBullet(shootPosition, rotation);
        }
    }

    protected virtual Transform SpawnBullet(Vector3 shootPosition)
    {
        Transform bullet = BulletsManager.instance.Spawn(BulletPlayer, shootPosition);
        BulletControler bulletControler = bullet.GetComponent<BulletControler>();
        //if (bulletControler != null) Debug.LogError("missing bulletControler in bullet");
        BulletDamageSender bulletDamageSender = bulletControler.bulletDamageSender;
        bulletDamageSender.damage = GetDamage();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    protected virtual Transform SpawnBullet(Vector3 shootPosition, Quaternion rotation)
    {
        Transform bullet = SpawnBullet(shootPosition);
        bullet.rotation = rotation;
        return bullet;
    }
    protected virtual float GetDamage()
    {
        return playerCtrl.playerLevel.CurrentLevel();
    }

    protected virtual void LoadStrikepoint()
    {
        strikePoint = PlayerCtrl.instance.playerModels.GetStrikePoints();
    }

}
