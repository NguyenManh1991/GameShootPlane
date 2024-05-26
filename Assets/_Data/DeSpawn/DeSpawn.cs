using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawn : MonoBehaviour
{
    

    public virtual void DeSpawning()
    {
    
        Destroy(transform.parent.gameObject);
    }

   

    
}
