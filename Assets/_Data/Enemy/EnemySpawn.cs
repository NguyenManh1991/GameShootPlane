using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemySpawn : MonoBehaviour
{
    public Transform enemyHolder;
    public string EnemyHolder = "EnemyHolder";
    public float timer = 0;
    public float spawnTime = 1f;

    public List<EnemyCtrl> enemies = new();

    protected virtual void Start()
    {
        LoadEnemyHolder();
        LoadEnemies();
        HideAll();
    }

    protected virtual void FixedUpdate()
    {
        Spawning();
    }
    protected virtual void LoadEnemyHolder()
    {
        enemyHolder =GameObject.Find(EnemyHolder).transform;
    }

    protected virtual void LoadEnemies()
    {
        foreach (Transform enemy in transform)
        {
            enemies.Add(enemy.GetComponent<EnemyCtrl>());
        }
    }
    protected virtual void HideAll()
    {
        foreach (EnemyCtrl enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    protected virtual void Spawning()
    {
        timer += Time.fixedDeltaTime;
        if (timer < spawnTime) return;
        timer = 0;

        var newEnemy = Instantiate(GetEnemy().gameObject);
        newEnemy.name = GetEnemy().name;
        newEnemy.transform.SetParent(enemyHolder.transform);
        newEnemy.SetActive(true);
        //ScoreManager.instance.Add("EnemyCount", 1);

    }

    protected virtual EnemyCtrl GetEnemy()
    {
        //int indexEnemy = 0;
        int indexEnemy = Random.Range(0, enemies.Count);
        return enemies[indexEnemy];
    }


}
