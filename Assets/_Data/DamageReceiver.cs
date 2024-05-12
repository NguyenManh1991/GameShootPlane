using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class DamageReceiver : MonoBehaviour
{
    public float hp = 0;
    public float maxHp = 10;

    private void OnEnable()
    {
        ResetHp();
    }

    protected virtual void ResetHp()
    {
        hp = maxHp;
    }

    public virtual void Damaged(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        Dead();
    }

    protected virtual void Dead()
    {
        if (IsAlive()) return;
        Debug.Log(transform.parent.name + "dying");

        DestroyEnemy();
    }

    protected virtual bool IsAlive()
    {
        return hp > 0;

    }

    protected virtual void DestroyEnemy()
    {
        Destroy(transform.parent.gameObject);
    }
}
