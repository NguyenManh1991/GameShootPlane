using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : Spawner
{
   
    public static FXManager instance;
   
    private void Awake()
    {
        if(FXManager.instance != null)
        {
            Debug.LogError("Only one BulletsManager allow", gameObject);
        }
        FXManager.instance = this;
    }


    protected void Reset()
    {
        holderName = "FxHolder";
    }

}
