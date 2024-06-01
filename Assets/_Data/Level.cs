using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int level = 1;
    public virtual void Up(int add = 1)
    {
        level += add;
    }

    public virtual int CurrentLevel()
    {
        return level;
    }
}
