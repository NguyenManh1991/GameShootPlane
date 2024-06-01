using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public DeSpawn deSpawn;
    public EnemyModel model;
    public EnemyDamageReceiver damageReceiver;
    private void Start()
    {
        deSpawn=transform.GetComponentInChildren<DeSpawn>();
        model= transform.GetComponentInChildren<EnemyModel>();
        damageReceiver=transform.GetComponentInChildren<EnemyDamageReceiver>();
    }
}
