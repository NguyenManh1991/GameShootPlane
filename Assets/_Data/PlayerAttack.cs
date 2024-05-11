using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    public float speedAttack = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating ("playerAttack",2f,speedAttack); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    protected virtual void playerAttack()
    {
        BulletsManager.instance.Spawn("BulletsPlayer", transform.position);
    }
}
