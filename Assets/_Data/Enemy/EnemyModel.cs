using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [SerializeField] protected List<Transform> explosionPoint;
    [SerializeField] string explosionName = "ExplosionPoints";
    
    protected virtual void Start()
    {
        LoadExplosionPoint();
    }

    protected virtual void LoadExplosionPoint()
    {
        explosionPoint.Clear();
        Transform explosionHolder = transform.Find(explosionName);
        if (explosionHolder == null ) return;
        foreach(Transform explosion in explosionHolder)
        {
            explosionPoint.Add(explosion);
        }
    }

    public virtual List<Transform> ExplosionPoint()
    {
        return explosionPoint;
    }
}
