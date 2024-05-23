using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLevelUp : MonoBehaviour
{
   public virtual void Clicked()
    {
    
        PlayerCtrl.instance.playerLevel.Up();
    }
}
