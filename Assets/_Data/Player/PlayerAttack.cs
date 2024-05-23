using System.Collections;
using System.Collections.Generic;
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
        fixedTimer += Time.fixedDeltaTime;
        if (fixedTimer < Delay()) return;
        fixedTimer = 0f;
        PlayerAttacking();
    }

    protected virtual float Delay()
    {
        int level = playerCtrl.playerLevel.level;
        finalDelay = baseDelay - (level * speedDelay);
        if(finalDelay < minDelay ) finalDelay = minDelay;
        return finalDelay;
    }

    protected virtual void PlayerAttacking()
    {
        Transform bullet = BulletsManager.instance.Spawn(BulletPlayer, transform.position);
        BulletControler bulletControler=bullet.GetComponent<BulletControler>();
        //if (bulletControler != null) Debug.LogError("missing bulletControler in bullet");
        BulletDamageSender bulletDamageSender = bulletControler.bulletDamageSender;
        bulletDamageSender.damage = GetDamage();


        bullet.gameObject.SetActive(true);
        

    }

    protected virtual float GetDamage()
    {
        return playerCtrl.playerLevel.level;
    }


}
