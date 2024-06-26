using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    public string BulletHolder = "BulletHolder";
    public Transform loadBulletHolder;
    public static BulletsManager instance;
    public List<Transform> bullets = new();
    private void Awake()
    {
        if(BulletsManager.instance != null)
        {
            Debug.LogError("Only one BulletsManager allow", gameObject);
        }
        BulletsManager.instance = this;
    }
    void Start()
    {
        LoadBulletHolder();
        LoadsBullets();
        HideAll();
    }
    protected virtual void LoadsBullets()
    {
        foreach (Transform bullet in transform)
        {
            bullets.Add(bullet);
        }
    }

    protected virtual void LoadBulletHolder()
    {
        loadBulletHolder = GameObject.Find(BulletHolder).transform;
    }

    public virtual Transform Spawn(string bulletName, Vector3 spawnPosition)
    {
        Transform bulletPrefab = GetBulletByName(bulletName);
        Transform newBullet = Instantiate(bulletPrefab);

        newBullet.transform.position = spawnPosition;
        newBullet.transform.SetParent(loadBulletHolder);
        return newBullet;
    }

    public virtual Transform GetBulletByName(string bulletName)
    {
        foreach (var bullet in bullets)
        {
            if (bullet.name == bulletName) return bullet;

        }
        return null;
    }
    protected virtual void HideAll()
    {
        foreach (var bullet in bullets)
        {
            bullet.gameObject.SetActive(false);
        }
    }
}
