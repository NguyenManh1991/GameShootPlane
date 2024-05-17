using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    public DeSpawn deSpawn;
    public string deSpawning = "DeSpawn";

    void Start()
    {
        deSpawn = transform.Find(deSpawning).GetComponent<DeSpawn>();

    }


}
