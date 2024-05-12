using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    public static BulletsManager instance;
    public List<Transform> bullets = new();
    private void Awake()
    {
        BulletsManager.instance = this;
    }
    void Start()
    {
        LoadsBullets();
         HideAll();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void LoadsBullets()
    {
        foreach (Transform bullet in transform)
        {
            bullets.Add(bullet);
        }
    }

    public virtual Transform Spawn(string bulletName, Vector3 spawnPosition)
    {
        Transform bulletPrefab = GetBulletByName(bulletName);
        Transform newBullet = Instantiate(bulletPrefab);

        newBullet.transform.position = spawnPosition;
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
        foreach(var bullet in bullets)
        {
            bullet.gameObject.SetActive(false);
        } 
    }
}
