using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public DeSpawn deSpawn;

    private void Start()
    {
        deSpawn=transform.GetComponentInChildren<DeSpawn>();
    }
}
