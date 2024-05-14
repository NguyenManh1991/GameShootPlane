using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [Header("Bullet")]
    public BulletControler bulletControler;

    private void Start()
    {
        bulletControler=transform.parent.GetComponent<BulletControler>();
    }

    protected override void DeSpawn()
    {
        bulletControler.deSpawn.DeSpawning();
        
    }
}
