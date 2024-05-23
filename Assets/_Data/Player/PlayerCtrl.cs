using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;
    public PlayerLevel playerLevel;
    public PlayerModels playerModels;
    protected virtual void Awake()
    {
        PlayerCtrl.instance = this;

    }
    protected virtual void Start()
    {
        GetPlayerLevelAndModels();
    }

    protected virtual void GetPlayerLevelAndModels()
    {
        playerLevel = GetComponentInChildren<PlayerLevel>();
        playerModels = GetComponentInChildren<PlayerModels>();
    }

}
