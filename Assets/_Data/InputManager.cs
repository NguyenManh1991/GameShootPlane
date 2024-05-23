using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public Vector2 mousePos;

    private void Awake()
    {
        InputManager.Instance = this;
    }
   
    void Update()
    {
        LoadMousePos();

    }

    protected virtual void LoadMousePos()
    {
        Vector3 mousePos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x=mousePos1.x;
        mousePos.y=mousePos1.y;
    }  
}
