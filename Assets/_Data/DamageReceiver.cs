
using Unity.VisualScripting;
using UnityEngine;


public class DamageReceiver : MonoBehaviour
{
    [SerializeField] protected float hp = 0;
    [SerializeField] protected float maxHp = 0;
   
   protected virtual void Start()
    {
       ResetHp();
    } 
    protected virtual void ResetHp()
    {
        hp = MaxHp();
    }
    public virtual float MaxHp()
    {
        return maxHp;
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

    public virtual float Hp()
    {
        return hp;
    }
}
