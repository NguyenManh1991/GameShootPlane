using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    public float attackDelay = 0.5f;
    public float fixedTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
      //InvokeRepeating ("playerAttack",2f,AttackDelay); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FixedAttacking();
    }

    protected virtual void playerAttack()
    {
      Transform bullet= BulletsManager.instance.Spawn("BulletsPlayer", transform.position);
       bullet.gameObject.SetActive(true);   
    }

    protected virtual void FixedAttacking()
    {
        fixedTimer += Time.fixedDeltaTime;
        if (fixedTimer < attackDelay) return;
        fixedTimer = 0f;
        playerAttack();
    }
}
