using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Vector2 position;
    public float speed = 2f;
    public Vector2 limitHorizon = new Vector2(-2.5f, 2.5f);
    public Vector2 limitVertical = new Vector2(-1f, 8.5f);
    void Update()
    {
        GetPosBuyInput();
        Move2Position();
    }

    protected virtual void Move2Position()
    {
        Vector3 target = new Vector3(position.x, position.y, transform.parent.position.z);
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, target, speed * Time.deltaTime);
    }
    protected virtual void GetPosBuyInput()
    {
        position = InputManager.Instance.mousePos;
        if (position.x < limitHorizon.x) position.x = limitHorizon.x;
        if (position.x > limitHorizon.y) position.x = limitHorizon.y;
        if (position.y < limitVertical.x) position.y = limitVertical.x;
        if (position.y > limitVertical.y) position.y = limitVertical.y;
    }
}
