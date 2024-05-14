using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    public DeSpawn deSpawn;


    void Start()
    {
        deSpawn = transform.Find("DeSpawn").GetComponent<DeSpawn>();

    }


}
