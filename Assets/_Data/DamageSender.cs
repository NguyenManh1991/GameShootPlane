using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [Header("Damage Sender")]
    public float damage = 1f;
    private void OnTriggerEnter(Collider other)
    {
        DamageReceiver receiver = other.GetComponent<DamageReceiver>();
        receiver.Damaged(damage);

        DeSpawn();
    }

    protected virtual void DeSpawn()
    {
        Debug.Log("go here");   
        Destroy(transform.parent.gameObject);
    }
}
