using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    public float attackDelay = 0.5f;
    public float fixedTimer = 0f;
    public string BulletPlayer = "BulletPlayer";

    void FixedUpdate()
    {
        FixedAttacking();
    }
    protected virtual void FixedAttacking()
    {
        fixedTimer += Time.fixedDeltaTime;
        if (fixedTimer < attackDelay) return;
        fixedTimer = 0f;
        PlayerAttacking();
    }

    protected virtual void PlayerAttacking()
    {
        Transform bullet = BulletsManager.instance.Spawn(BulletPlayer, transform.position);
        bullet.gameObject.SetActive(true);
        //ScoreManager.instance.Add("BulletCount", 1);

    }


}
