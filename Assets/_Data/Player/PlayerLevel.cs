using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : Level
{
    public PlayerCtrl playerCtrl;

    protected virtual void Start()
    {
        playerCtrl=GetComponentInParent<PlayerCtrl>();
    }
    public override void Up(int add = 1)
    {

        if (!GoldDeduct())
        {
            Debug.LogWarning("not enough monney");
            return;
        }
        base.Up(add);

        playerCtrl.playerModels.ModelActive(level-1);
    }

    protected virtual bool GoldDeduct()
    {
        int cost = GetLevelUpCost();
        return ScoreManager.instance.Deduct(ScoreType.GoldCount.ToString(), cost);
    }
    protected virtual int GetLevelUpCost()
    {
        return level;
    }
}
