using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    public DeSpawn deSpawn;
    public BulletDamageSender bulletDamageSender;
    string deSpawning = "DeSpawn";

    void Awake()
    {
        deSpawn = transform.Find(deSpawning).GetComponent<DeSpawn>();
        bulletDamageSender= GetComponentInChildren<BulletDamageSender>();
    }


}
