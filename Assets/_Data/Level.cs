using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public virtual void Up(int add = 1)
    {
        level += add;
    }
}
