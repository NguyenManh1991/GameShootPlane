using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiHpEnemy : MonoBehaviour
{
    public EnemyCtrl enemyCtrl;
    [SerializeField] protected float hpEnemy;
    TextMeshPro textHpEnemy;
    void Start()
    {
        enemyCtrl = GetComponentInParent<EnemyCtrl>();
        LoadTextHpEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHpEnemy();
    }
    
    protected virtual void LoadTextHpEnemy()
    {
        textHpEnemy=GetComponent<TextMeshPro>();   
    }
    protected virtual void UpdateHpEnemy()
    {
        hpEnemy = enemyCtrl.damageReceiver.Hp();
        textHpEnemy.text=hpEnemy.ToString();
    }
}
