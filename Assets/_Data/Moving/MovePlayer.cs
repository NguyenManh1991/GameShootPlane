using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Vector2 position;
    public float speed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPosBuyInput();
        Move2Position();
    }

    protected virtual void Move2Position()
    {
        Vector3 target = new Vector3(position.x, position.y, transform.parent.position.z);
        transform.parent.position= Vector3.MoveTowards(transform.parent.position, target, speed*Time.deltaTime);
    }
    protected virtual void GetPosBuyInput()
    {
        position = InputManager.Instance.mousePos;
    }
}
