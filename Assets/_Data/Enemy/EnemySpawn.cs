
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour
{
    public Transform enemyHolder;
    public string EnemyHolderName = "EnemyHolder";
    public float timer = 0;
    public float spawnTime = 1f;
    public float deductTimeByLevel = 0.01f;
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
        enemyHolder =GameObject.Find(EnemyHolderName).transform;
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
        if (timer < SpawnTimeByLevel()) return;
        timer = 0;
        EnemyCtrl newEnemyCtrl = GetEnemy();
        var newEnemy = Instantiate(newEnemyCtrl.gameObject);
        newEnemy.name = newEnemyCtrl.name;
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

    protected virtual float SpawnTimeByLevel()
    {
        int level = GameLevel.Instance.CurrentLevel();

        spawnTime = 1 - level * deductTimeByLevel;
        if (spawnTime <= 0) spawnTime = 0.01f;
         return spawnTime;
    }
}
