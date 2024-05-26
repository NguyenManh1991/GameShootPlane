using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTimer : DeSpawn
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 3f;

    protected virtual void FixedUpdate()
    {
        DestroyByTimer();
    }

    protected virtual void DestroyByTimer()
    {
        timer += Time.fixedDeltaTime;
        if (timer < timeDelay) return;
        timer = 0f;
        DeSpawning();

    }
   
}
