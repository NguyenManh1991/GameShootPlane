using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;
#pragma warning disable IDE0052 // Remove unread private members
    [SerializeField] private bool isGameOver = false;
#pragma warning restore IDE0052 // Remove unread private members
    [SerializeField] protected int enemyPassed = 0;
    [SerializeField] protected int maxEnemyPassed = 10;
    private void Awake()
    {
        if (GameOver.Instance != null) Debug.LogError("Only one GameOver allow", gameObject);
        GameOver.Instance = this;
    }

    protected virtual void FixedUpdate()
    {
        UpdateEnemyPassed();
    }

    protected virtual void UpdateEnemyPassed()
    {
        Score enemyPassedScore = ScoreManager.instance.Get(ScoreType.EnemePassed.ToString());
        if (enemyPassedScore == null) enemyPassed = 0;
        else enemyPassed = enemyPassedScore.value;
        if (enemyPassed >= maxEnemyPassed) isGameOver = true;
    }

    public virtual bool IsGameOver()
    {
        return isGameOver;
    }

    public virtual void RePlay()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public virtual int GetEnemyPassed()
    {
        return maxEnemyPassed - enemyPassed;
    }
}
