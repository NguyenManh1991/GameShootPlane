using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [Header("Bullet")]
    public float speed = 10f;
   
    void Update()
    {
       this. transform.parent.Translate(Vector3.right*speed*Time.deltaTime);
    }
}
